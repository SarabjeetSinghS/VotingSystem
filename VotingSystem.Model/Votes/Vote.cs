using System.ComponentModel.DataAnnotations;
using VotingSystem.Infrastructure.Entity;
using VotingSystem.Model.Users;

namespace VotingSystem.Model.Votes
{
    public class Vote : BaseEntity
    {
        [Required]
        public int CandidateId { get; set; }
        [Required]
        public int VoterId { get; set; }
        [Required]
        public int CandidateCategoryId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Voter Voter { get; set; }
        public virtual CandidateCategory CandidateCategory { get; set; }
    }
}
