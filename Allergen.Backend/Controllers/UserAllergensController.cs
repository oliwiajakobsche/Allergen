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


        // GET: api/UserAllergens/5
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserAllergens(int UserId)
        {
            var userAllergens = await _context.UserAllergens.Where(x => x.UserId == UserId).ToListAsync();
            var allergens = await _context.Allergens.ToListAsync();

            var result = from a in allergens
                         join ua in userAllergens on a.Id equals ua.AllergenId into r
                         from output in r.DefaultIfEmpty()
                         select new UserAllergenDto()
                         {
                             AllergenId = a.Id,
                             AllergenName = a.Name,
                             UserAllergenId = output?.AllergenId ?? 0
                         };

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/UserAllergens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAllergen(int id, UserAllergen userAllergen)
        {
            if (id != userAllergen.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAllergen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAllergenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserAllergens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAllergen>> PostUserAllergen(UserAllergen userAllergen)
        {
            _context.UserAllergens.Add(userAllergen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAllergen", new { id = userAllergen.Id }, userAllergen);
        }

        // DELETE: api/UserAllergens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAllergen(int id)
        {
            var userAllergen = await _context.UserAllergens.FindAsync(id);
            if (userAllergen == null)
            {
                return NotFound();
            }

            _context.UserAllergens.Remove(userAllergen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAllergenExists(int id)
        {
            return _context.UserAllergens.Any(e => e.Id == id);
        }
    }
}
