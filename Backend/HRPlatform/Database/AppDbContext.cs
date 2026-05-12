using HRPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRPlatform.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills {  get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Candidate>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Skill>().HasIndex(s => s.Name).IsUnique();
        }
    }
}
