using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Model.Users;
using VotingSystem.Model.Votes;
using VotingSystem.Repository.Repositories.CandidateXCategories;
using VotingSystem.Repository.Repositories.Voters;
using VotingSystem.Repository.Repositories.Votes;
using VotingSystem.Service.Abstract;

namespace VotingSystem.Service.Services.Votes
{
    public class VoteService : BaseService<Vote, IVoteRepository>, IVoteService
    {
        private readonly ICandidateXCategoryRepository _candidateXCategoryRepository;
        private readonly IVoterRepository _voterRepository;
        private readonly IVoteRepository _voteRepository;
        public VoteService(IVoteRepository voteRepository, ICandidateXCategoryRepository candidateXCategoryRepository, IVoterRepository voterRepository) : base(voteRepository)
        {
            this._voteRepository = voteRepository;
            this._voterRepository = voterRepository;
            this._candidateXCategoryRepository = candidateXCategoryRepository;
        }

        public async Task<IList<Vote>> GetVotesForCandidate(int candidateId) => await this._voteRepository.GetVotesForCandidate(candidateId);

        public async Task<bool> IsVoteCastForCategoryByVoter(int voterId, int categoryId) => await this._voteRepository.IsVoteCastForCategoryByVoter(voterId, categoryId);

        public async Task<UserStatusInDatabase> IsVoterAndCandidateIsValid(int voterId, int candidateId, int candidateCategoryId)
        {
            var IsVoterExist = await this._voterRepository.GetAsync(voterId) != null ? true : false;
            var candidateToSearch = new CandidateXCategory { CandidateId = candidateId, CandidateCategoryId = candidateCategoryId };
            var IsCandidateExist = await this._candidateXCategoryRepository.GetCandidate(candidateToSearch) != null ? true : false;

            return new UserStatusInDatabase { VoterExist = IsVoterExist, CandidateExist = IsCandidateExist };
        }

        public async Task<bool> CastAVote(Vote vote) =>
            await this._voteRepository.AddVote(vote);
    }
}
