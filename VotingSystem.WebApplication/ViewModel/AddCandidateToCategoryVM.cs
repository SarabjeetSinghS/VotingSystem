
namespace VotingSystem.WebApplication.ViewModel
{
    public record AddCandidateToCategoryVM
    {
        public int CandidateCategoryId { get; init; }
        public int CandidateId { get; init; }
    }
}
