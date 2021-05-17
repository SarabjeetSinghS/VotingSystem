using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using VotingSystem.Repository.Repositories.CandidateCategories;
using VotingSystem.Repository.Repositories.CandidateXCategories;
using VotingSystem.Repository.Repositories.Canditates;
using VotingSystem.Repository.Repositories.Voters;
using VotingSystem.Repository.Repositories.Votes;
using VotingSystem.Service.Services.CandidateCategories;
using VotingSystem.Service.Services.CandidateXCategories;
using VotingSystem.Service.Services.Canditates;
using VotingSystem.Service.Services.Voters;
using VotingSystem.Service.Services.Votes;

namespace VotingSystem.WebApplication.Installers
{
    public class DependencyResolutionIntsaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register project dependencies
            services.AddSingleton<HttpClient>();

            // register repositories
            services.AddScoped<ICandidateCategoryRepository, CandidateCategoryRepository>();
            services.AddScoped<ICandidateXCategoryRepository, CandidateXCategoryRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IVoterRepository, VoterRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();

            // register services
            services.AddScoped<ICandidateCategoryService, CandidateCategoryService>();
            services.AddScoped<ICandidateXCategoryService, CandidateXCategoryService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVoterService, VoterService>();
            services.AddScoped<IVoteService, VoteService>();
        }
    }
}
