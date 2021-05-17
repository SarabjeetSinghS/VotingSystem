using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Model.Users;
using VotingSystem.Repository.Context;
using VotingSystem.Repository.Repositories.Abstract;

namespace VotingSystem.Repository.Repositories.CandidateXCategories
{
    public class CandidateXCategoryRepository : BaseRepository<CandidateXCategory>, ICandidateXCategoryRepository
    {
        private readonly VotingSystemContext _votingSystemContext;
        public CandidateXCategoryRepository(VotingSystemContext votingSystemContext) : base(votingSystemContext)
        {
            this._votingSystemContext = votingSystemContext;
        }

        public async Task<CandidateXCategory> GetCandidate(CandidateXCategory candidateXCategory) =>
           await this._votingSystemContext.CandidateXCategories.FirstOrDefaultAsync(c =>
            c.CandidateId == candidateXCategory.CandidateId && c.CandidateCategoryId == candidateXCategory.CandidateCategoryId);

        public override IAsyncEnumerable<CandidateXCategory> GetAllAsync() =>
            this._votingSystemContext.CandidateXCategories.Include(x => x.Candidate).Include(x => x.CandidateCategory).AsAsyncEnumerable();
    }
}
