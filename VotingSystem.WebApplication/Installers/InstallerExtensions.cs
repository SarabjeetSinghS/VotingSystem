using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace VotingSystem.WebApplication.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServiceAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            // get all the installers which implement IIntaller interface
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                    typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));

        }
    }
}
