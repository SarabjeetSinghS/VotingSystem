using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VotingSystem.WebApplication.Installers
{
    public class WebApiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers(opt =>
            opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>()
            );
            services.AddHttpContextAccessor();
        }
    }
}
