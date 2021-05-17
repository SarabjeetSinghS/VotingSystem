using System.Threading.Tasks;
using VotingSystem.Infrastructure.Repository;
using VotingSystem.Model.Users;

namespace VotingSystem.Repository.Repositories.CandidateXCategories
{
    public interface ICandidateXCategoryRepository : IBaseRepository<CandidateXCategory>
    {
        Task<CandidateXCategory> GetCandidate(CandidateXCategory candidateXCategory);
    }
}
