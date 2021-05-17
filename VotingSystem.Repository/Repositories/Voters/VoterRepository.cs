using VotingSystem.Model.Users;
using VotingSystem.Repository.Context;
using VotingSystem.Repository.Repositories.Abstract;

namespace VotingSystem.Repository.Repositories.Voters
{
    public class VoterRepository : BaseRepository<Voter>, IVoterRepository
    {
        private readonly VotingSystemContext _votingSystemContext;
        public VoterRepository(VotingSystemContext votingSystemContext) : base(votingSystemContext)
        {
            this._votingSystemContext = votingSystemContext;
        }
    }
}
