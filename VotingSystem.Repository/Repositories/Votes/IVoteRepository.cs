using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Infrastructure.Repository;
using VotingSystem.Model.Votes;

namespace VotingSystem.Repository.Repositories.Votes
{
    public interface IVoteRepository : IBaseRepository<Vote>
    {
        Task<bool> IsVoteCastForCategoryByVoter(int voterId, int categoryId);
        Task<IList<Vote>> GetAllVotesByVoter(int voterId);
        Task<IList<Vote>> GetVotesForCandidate(int candidateId);
        Task<bool> AddVote(Vote vote);
    }
}
