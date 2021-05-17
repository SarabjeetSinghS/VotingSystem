using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VotingSystem.Infrastructure.Entity;

namespace VotingSystem.Model.Users
{
    public class CandidateCategory : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Type { get; set; }
    }
}
