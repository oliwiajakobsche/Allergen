using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Allergen.Backend.Installers
{
    internal interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
