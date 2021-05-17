using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Infrastructure.Entity
{
    public class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
