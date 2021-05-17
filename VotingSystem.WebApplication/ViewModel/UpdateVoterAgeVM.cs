using System;
using System.ComponentModel.DataAnnotations;
using VotingSystem.Infrastructure.Entity;

namespace VotingSystem.WebApplication.ViewModel
{
    public record UpdateVoterAgeVM
    {
        public int Id { get; init; }
        [Required]
        [AgeConstraint(18, ErrorMessage = "Voter must be over age of 18")]
        public DateTime Birthday { get; init; }
    }
}
