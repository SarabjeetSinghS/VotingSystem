using Microsoft.EntityFrameworkCore;
using VotingSystem.Model.Users;
using VotingSystem.Model.Votes;

namespace VotingSystem.Repository.Context
{
    public class VotingSystemContext : DbContext
    {
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateCategory> CandidateCategories { get; set; }
        public DbSet<CandidateXCategory> CandidateXCategories { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public VotingSystemContext(DbContextOptions<VotingSystemContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Voter>();
            modelBuilder.Entity<Candidate>();
            modelBuilder.Entity<CandidateCategory>();
            modelBuilder.Entity<CandidateXCategory>();
            modelBuilder.Entity<Vote>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
