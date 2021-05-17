using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace VotingSystem.WebApplication.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Voting System",
                    Version = "v1",
                    Description = "The rest api interface for VotingSystem",
                    TermsOfService = new Uri("https://www.VotingSystem.com/terms-and-conditions"),
                    Contact = new OpenApiContact { Name = "VotingSystem Team", Email = "support@votingsystem.com" },
                    License = new OpenApiLicense { Name = "Use under VotingSystem", Url = new Uri("http://www.VotingSystem.com/privacy-policy") }
                });

                options.DocInclusionPredicate((docName, api) =>
                   api.RelativePath.Contains(docName));
            });
        }
    }
}
