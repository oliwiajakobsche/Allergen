using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllergenBackend.Database;
using Microsoft.Extensions.Logging;
using AllergenBackend.Contracts.V1.Responses;
using System.Linq;
using System.Collections.Generic;

namespace AllergenBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllergenController : Controller
    {
        private readonly DbAllergyContext _context;
        private readonly ILogger<AllergenController> _logger;

        public AllergenController(DbAllergyContext context, ILogger<AllergenController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Allergen
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allergens = await _context.Allergens.ToListAsync();
            var allergensResponse = from x in allergens
                          select new AllergenDto()
                          {
                              Id = x.Id,
                              Name = x.Name
                          };

            if (!allergensResponse.Any())
            {
                return NotFound();
            }

            return Ok(allergensResponse);
        }
    }
}
