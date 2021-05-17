using System.ComponentModel.DataAnnotations;

namespace VotingSystem.WebApplication.ViewModel
{
    public record AddCategoryVM
    {
        [Required]
        public string Type { get; init; }
    }
}
