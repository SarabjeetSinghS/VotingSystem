using System.Text.Json.Serialization;
using VotingSystem.Infrastructure.Entity;

namespace VotingSystem.Model.Users
{
    public class CandidateXCategory : BaseEntity
    {
        public int CandidateId { get; set; }
        public int CandidateCategoryId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual CandidateCategory CandidateCategory { get; set; }
    }
}
