using Microsoft.EntityFrameworkCore;
using Allergen.Backend.Models.Entities;

namespace Allergen.Backend.Database
{
    public partial class DbAllergyContext : DbContext
    {
        public DbAllergyContext(DbContextOptions<DbAllergyContext> options)
            : base(options)
        {
        }

        public DbSet<AllergenEfo> AllergenEfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO
        }
    }
}
