using System;
using System.ComponentModel.DataAnnotations;
using VotingSystem.Infrastructure.Entity;

namespace VotingSystem.WebApplication.ViewModel
{
    public record AddVoterVM
    {
        [Required]
        public string FirstName { get; init; }
        public string MiddleName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        [AgeConstraint(18, ErrorMessage = "Voter must be over age of 18")]
        public DateTime Birthday { get; init; }
    }
}
