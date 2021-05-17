using VotingSystem.Model.Users;
using VotingSystem.Repository.Repositories.Canditates;
using VotingSystem.Service.Abstract;

namespace VotingSystem.Service.Services.Canditates
{
    public class CandidateService : BaseService<Candidate, ICandidateRepository>, ICandidateService
    {
        public CandidateService(ICandidateRepository candidateRepository) : base(candidateRepository)
        {
        }
    }
}
