using VotingSystem.Model.Users;
using VotingSystem.Repository.Repositories.Voters;
using VotingSystem.Service.Abstract;

namespace VotingSystem.Service.Services.Voters
{
    public class VoterService : BaseService<Voter, IVoterRepository>, IVoterService
    {
        public VoterService(IVoterRepository voterRepository) : base(voterRepository)
        {

        }
    }
}
