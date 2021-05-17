using VotingSystem.Model.Users;
using VotingSystem.Model.Votes;
using VotingSystem.WebApplication.ViewModel;

namespace VotingSystem.WebApplication.Mapper
{
    public static class VotingSystemDomainMapper
    {
        public static Voter ToVoter(this AddVoterVM viewModel)
        {
            return new Voter
            {
                FirstName = viewModel.FirstName,
                MiddleName = viewModel.MiddleName,
                LastName = viewModel.LastName,
                Birthday = viewModel.Birthday
            };
        }

        public static Candidate ToCandidate(this AddCandidateVM viewModel)
        {
            return new Candidate
            {
                FirstName = viewModel.FirstName,
                MiddleName = viewModel.MiddleName,
                LastName = viewModel.LastName,
            };
        }

        public static CandidateCategory ToCandidateCategory(this AddCategoryVM viewModel)
        => new CandidateCategory { Type = viewModel.Type };

        public static CandidateXCategory ToCandidateXCategory(this AddCandidateToCategoryVM viewModel) =>
            new CandidateXCategory { CandidateCategoryId = viewModel.CandidateCategoryId, CandidateId = viewModel.CandidateId };

        public static Vote ToVote(this AddVoteVM viewModel) =>
        new Vote { CandidateCategoryId = viewModel.CandidateCategoryId, CandidateId = viewModel.CandidateId, VoterId = viewModel.VoterId };
    }
}
