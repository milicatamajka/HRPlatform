using HRPlatform.Models;

namespace HRPlatform.Database.Repositories.Interfaces
{
    public interface ISkillDbRepository
    {
        public Skill Create (Skill skill);
        public Skill GetById(int skillId);
    }
}
