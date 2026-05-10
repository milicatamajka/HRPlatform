using HRPlatform.Database.Repositories.Interfaces;
using HRPlatform.Models;
using Microsoft.EntityFrameworkCore;

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

        public Candidate GetById(int candidateId)
        {
            var candidate = _context.Candidates.Include(c => c.Skills).FirstOrDefault(c => c.Id == candidateId);
            if (candidate == null) throw new Exception("Candidate not found.");
            return candidate;
        }

        public Candidate Update(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            _context.SaveChanges();
            return candidate;
        }

        public void Delete(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
            _context.SaveChanges() ;
        }
    }
}
