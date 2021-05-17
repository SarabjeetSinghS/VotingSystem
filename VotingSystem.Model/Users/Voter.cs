using System;
using System.ComponentModel.DataAnnotations;
using VotingSystem.Infrastructure.Entity;

namespace VotingSystem.Model.Users
{
    public class Voter : User
    {
        [Required]
        [AgeConstraint(18, ErrorMessage = "Voter must be over age of 18")]
        public DateTime Birthday { get; set; }
    }
}
