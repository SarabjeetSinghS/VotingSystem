using System.ComponentModel.DataAnnotations;

namespace VotingSystem.WebApplication.ViewModel
{
    public record AddVoteVM
    {
        [Required]
        public int CandidateId { get; set; }
        [Required]
        public int VoterId { get; set; }
        [Required]
        public int CandidateCategoryId { get; set; }
    }
}
