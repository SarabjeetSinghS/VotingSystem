using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VotingSystem.Repository.Context;

namespace VotingSystem.WebApplication.Installers
{
    public class SqlDbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VotingSystemContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("VotingSystemSqlContext"),
                    b => b.MigrationsAssembly("VotingSystem.Repository")));
        }
    }
}
