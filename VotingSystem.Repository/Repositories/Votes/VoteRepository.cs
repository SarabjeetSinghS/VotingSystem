using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Model.Votes;
using VotingSystem.Repository.Context;
using VotingSystem.Repository.Repositories.Abstract;

namespace VotingSystem.Repository.Repositories.Votes
{
    public class VoteRepository : BaseRepository<Vote>, IVoteRepository
    {
        private readonly VotingSystemContext _votingSystemContext;
        public VoteRepository(VotingSystemContext votingSystemContext) : base(votingSystemContext)
        {
            this._votingSystemContext = votingSystemContext;
        }

        public async Task<IList<Vote>> GetVotesForCandidate(int candidateId) =>
            await this._votingSystemContext.Votes.Where(c => c.CandidateId == candidateId).ToListAsync();


        public async Task<IList<Vote>> GetAllVotesByVoter(int voterId) =>
            await this._votingSystemContext.Votes.Where(c => c.VoterId == voterId).ToListAsync();

        public async Task<bool> IsVoteCastForCategoryByVoter(int voterId, int categoryId) =>
            await this._votingSystemContext.Votes.AnyAsync(c => c.VoterId == voterId && c.CandidateId == categoryId);

        public async Task<bool> AddVote(Vote vote)
        {
            await this._votingSystemContext.Votes.AddAsync(vote);
            await this._votingSystemContext.SaveChangesAsync();
            return true;
        }

    }
}
