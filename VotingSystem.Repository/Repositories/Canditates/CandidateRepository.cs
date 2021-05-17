using VotingSystem.Model.Users;
using VotingSystem.Repository.Context;
using VotingSystem.Repository.Repositories.Abstract;

namespace VotingSystem.Repository.Repositories.Canditates
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        private readonly VotingSystemContext _votingSystemContext;

        public CandidateRepository(VotingSystemContext votingSystemContext) : base(votingSystemContext)
        {
            this._votingSystemContext = votingSystemContext;
        }
    }

}
