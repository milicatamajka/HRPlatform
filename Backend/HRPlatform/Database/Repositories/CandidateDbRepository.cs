using HRPlatform.Database.Repositories.Interfaces;
using HRPlatform.Models;

namespace HRPlatform.Database.Repositories
{
    public class CandidateDbRepository : ICandidateDbRepository
    {
        private readonly AppDbContext _context;

        public CandidateDbRepository(AppDbContext context)
        {
            _context = context;
        }

        public Candidate Create(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return candidate;
        }
    }
}
