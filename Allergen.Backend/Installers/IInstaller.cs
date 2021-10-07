using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllergenBackend.Installers
{
    internal interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
