using AutoMapper;
using HRPlatform.Database.Repositories.Interfaces;
using HRPlatform.Dtos;
using HRPlatform.Models;
using HRPlatform.Services.Interfaces;

namespace HRPlatform.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillDbRepository _skillDbRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillDbRepository skillDbRepository, IMapper mapper)
        {
            _skillDbRepository = skillDbRepository;
            _mapper = mapper;
        }

        public SkillDto Create(SkillDto skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            _skillDbRepository.Create(skill);
            return _mapper.Map<SkillDto>(skill);
        }

    }
}
