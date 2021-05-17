using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VotingSystem.Infrastructure.Entity;

namespace VotingSystem.Model.Users
{
    public abstract class User : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "varchar")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }
    }
}
