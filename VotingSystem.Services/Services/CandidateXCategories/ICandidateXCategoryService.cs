using System.Threading.Tasks;
using VotingSystem.Infrastructure.Service;
using VotingSystem.Model.Users;

namespace VotingSystem.Service.Services.CandidateXCategories
{
    public interface ICandidateXCategoryService : IBaseService<CandidateXCategory>
    {
        Task<CandidateXCategory> GetCandidate(CandidateXCategory candidateXCategory);
    }
}
