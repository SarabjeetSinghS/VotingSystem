using VotingSystem.Model.Users;
using VotingSystem.Repository.Context;
using VotingSystem.Repository.Repositories.Abstract;

namespace VotingSystem.Repository.Repositories.CandidateCategories
{
    public class CandidateCategoryRepository : BaseRepository<CandidateCategory>, ICandidateCategoryRepository
    {
        private readonly VotingSystemContext _votingSystemContext;
        public CandidateCategoryRepository(VotingSystemContext votingSystemContext) : base(votingSystemContext)
        {
            this._votingSystemContext = votingSystemContext;
        }
    }
}
