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
    public class PollenCallendarsController : ControllerBase
    {
        private readonly DbAllergyContext _context;

        public PollenCallendarsController(DbAllergyContext context)
        {
            _context = context;
        }

        // GET: api/PollenCallendars
        [HttpGet("User/{userId}/{date}")]
        public async Task<ActionResult<IEnumerable<UserPolluteCalendarDto>>> GetUserPollenCallendars(int userId, DateTime date)
        {
            
            var userAllergens = await _context.UserAllergens.Where(x => x.UserId == userId).ToListAsync();
            var callendar = await _context.PollenCallendars.Where(x => x.Date == date).ToListAsync();
            var allergens = await _context.Allergens.ToListAsync();

            var result = from ua in userAllergens
                         join a in allergens on ua.AllergenId equals a.Id
                         join c in callendar on ua.AllergenId equals c.AllergenId 
                         select new UserPolluteCalendarDto()
                         {
                             AllergenName = a.Name,
                             ImpactLevel = c.ImpactLevel
                         };

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.OrderBy(x=>x.AllergenName));
        }

        // GET: api/PollenCallendars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollenCallendar>> GetPollenCallendar(int id)
        {
            var pollenCallendar = await _context.PollenCallendars.FindAsync(id);

            if (pollenCallendar == null)
            {
                return NotFound();
            }

            return pollenCallendar;
        }

    }
}
