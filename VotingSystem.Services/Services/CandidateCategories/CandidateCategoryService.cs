using VotingSystem.Model.Users;
using VotingSystem.Repository.Repositories.CandidateCategories;
using VotingSystem.Service.Abstract;

namespace VotingSystem.Service.Services.CandidateCategories
{
    public class CandidateCategoryService : BaseService<CandidateCategory, ICandidateCategoryRepository>, ICandidateCategoryService
    {
        public CandidateCategoryService(ICandidateCategoryRepository candidateCategoryRepository) : base(candidateCategoryRepository)
        {
        }
    }
}
