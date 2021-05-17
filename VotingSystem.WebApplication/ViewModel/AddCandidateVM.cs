using System.ComponentModel.DataAnnotations;

namespace VotingSystem.WebApplication.ViewModel
{
    public record AddCandidateVM
    {
        [Required]
        public string FirstName { get; init; }
        public string MiddleName { get; init; }
        [Required]
        public string LastName { get; init; }
    }
}
