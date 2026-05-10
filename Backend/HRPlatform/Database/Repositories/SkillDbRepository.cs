using HRPlatform.Database.Repositories.Interfaces;
using HRPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRPlatform.Database.Repositories
{
    public class SkillDbRepository : ISkillDbRepository
    {
        private readonly AppDbContext _context;

        public SkillDbRepository(AppDbContext context)
        {
            _context = context;
        }

        public Skill Create(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return skill;
        }

        public Skill GetById(int skillId) 
        { 
            var skill = _context.Skills.Include(s => s.Candidates).FirstOrDefault(s => s.Id == skillId);
            if (skill == null) throw new Exception("Skill not found.");
            return skill;
        }
    }
}
