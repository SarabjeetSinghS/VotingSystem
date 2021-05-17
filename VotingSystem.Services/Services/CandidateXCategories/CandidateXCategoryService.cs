using System.Threading.Tasks;
using VotingSystem.Model.Users;
using VotingSystem.Repository.Repositories.CandidateXCategories;
using VotingSystem.Service.Abstract;

namespace VotingSystem.Service.Services.CandidateXCategories
{
    public class CandidateXCategoryService : BaseService<CandidateXCategory, ICandidateXCategoryRepository>, ICandidateXCategoryService
    {
        private readonly ICandidateXCategoryRepository _candidateXCategoryRepository;
        public CandidateXCategoryService(ICandidateXCategoryRepository candidateCategoryRepository) : base(candidateCategoryRepository)
        {
            this._candidateXCategoryRepository = candidateCategoryRepository;
        }

        public async Task<CandidateXCategory> GetCandidate(CandidateXCategory candidateXCategory) =>
            await this._candidateXCategoryRepository.GetCandidate(candidateXCategory);
    }
}
