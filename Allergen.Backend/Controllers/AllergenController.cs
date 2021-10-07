using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Allergen.Backend.Database;
using Microsoft.Extensions.Logging;

namespace Allergen.Backend.Controllers
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
            var result = await _context.AllergenEfo.ToListAsync();
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
