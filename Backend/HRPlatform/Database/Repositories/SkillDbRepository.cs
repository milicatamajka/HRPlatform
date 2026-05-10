using HRPlatform.Database.Repositories.Interfaces;
using HRPlatform.Models;

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
    }
}
