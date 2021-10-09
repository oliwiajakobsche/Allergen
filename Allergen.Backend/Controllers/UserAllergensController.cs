using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllergenBackend.Database;
using AllergenBackend.Models;
using AllergenBackend.Contracts.V1.Responses;
using AllergenBackend.Contracts.V1.Requests;

namespace AllergenBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAllergensController : ControllerBase
    {
        private readonly DbAllergyContext _context;

        public UserAllergensController(DbAllergyContext context)
        {
            _context = context;
        }


        // GET: api/UserAllergens/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAllergens(int userId)
        {
            var userAllergens = await _context.UserAllergens.Where(x => x.UserId == userId).ToListAsync();
            var allergens = await _context.Allergens.ToListAsync();

            var result = from a in allergens
                         join ua in userAllergens on a.Id equals ua.AllergenId into r
                         from output in r.DefaultIfEmpty()
                         select new UserAllergenDto()
                         {
                             AllergenId = a.Id,
                             AllergenName = a.Name,
                             UserAllergenId = output?.Id ?? 0
                         };

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE: api/UserAllergens/{userId}/{allergenId}
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAllergen(UserAllergenDeleteRequest request)
        {
            var userAllergen = await _context.UserAllergens.Where(x => x.AllergenId == request.AllergenId && x.UserId == request.UserId).FirstOrDefaultAsync();

            if (userAllergen == null)
            {
                return NotFound();
            }

            _context.UserAllergens.Remove(userAllergen);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/UserAllergens
        [HttpPost]
        public async Task<ActionResult<UserAllergen>> PostUserAllergen(UserAllergenCreateRequest request)
        {
            var checkIfExist = await _context.UserAllergens.Where(x => x.AllergenId == request.AllergenId && x.UserId == request.UserId).FirstOrDefaultAsync();

            var userAllergenNew = new UserAllergen
            {
                AllergenId = request.AllergenId,
                UserId = request.UserId,
                Created = DateTime.Now
            };

            if (checkIfExist == null)
            {
                _context.UserAllergens.Add(userAllergenNew);
                await _context.SaveChangesAsync();
            }

            return Created("GetUserAllergen", new { id = userAllergenNew.Id });
        }

    }
}
