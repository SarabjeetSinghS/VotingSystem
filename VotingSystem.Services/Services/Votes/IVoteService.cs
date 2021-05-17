using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Infrastructure.Service;
using VotingSystem.Model.Votes;

namespace VotingSystem.Service.Services.Votes
{
    public interface IVoteService : IBaseService<Vote>
    {
        Task<bool> IsVoteCastForCategoryByVoter(int voterId, int categoryId);
        Task<IList<Vote>> GetVotesForCandidate(int candidateId);
        Task<UserStatusInDatabase> IsVoterAndCandidateIsValid(int voterId, int candidateId, int candidateCategoryId);
        Task<bool> CastAVote(Vote vote);
    }
}
