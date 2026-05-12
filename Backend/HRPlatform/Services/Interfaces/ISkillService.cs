using HRPlatform.Dtos;

namespace HRPlatform.Services.Interfaces
{
    public interface ISkillService
    {
        public SkillDto Create(SkillDto skillDto);
        public List<SkillDto> GetAll();
    }
}
