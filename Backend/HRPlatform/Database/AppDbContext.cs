using HRPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRPlatform.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills {  get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
