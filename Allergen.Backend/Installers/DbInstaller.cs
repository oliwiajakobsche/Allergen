using AllergenBackend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllergenBackend.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //TODO: Change connection string
            services.AddDbContext<DbAllergyContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DbAllergyTest")));
        }
    }
}
