using HRPlatform.Models;
using HRPlatform.Dtos;
using HRPlatform.Mappers;
using AutoMapper;
using HRPlatform.Services.Interfaces;
using HRPlatform.Database.Repositories.Interfaces;

namespace HRPlatform.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateDbRepository _candidateDbRepository;
        private readonly ISkillDbRepository _skillDbRepository;
        private readonly IMapper _mapper;
        public CandidateService(ICandidateDbRepository candidateDbRepository, ISkillDbRepository skillDbRepository, IMapper mapper) 
        {
            _candidateDbRepository = candidateDbRepository;
            _skillDbRepository = skillDbRepository;
            _mapper = mapper;
        }

        public CandidateDto Create(CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);
            _candidateDbRepository.Create(candidate);
            return _mapper.Map<CandidateDto>(candidate);
        }

        public void AddSkill(int candidateId, int skillId)
        {
            var candidate = _candidateDbRepository.GetById(candidateId);
            var skill = _skillDbRepository.GetById(skillId);

            if (candidate.Skills.Any(s => s.Id == skillId))
            {
                throw new Exception("Candidate already has this skill.");
            }

            candidate.Skills.Add(skill);
            _candidateDbRepository.Update(candidate);

        }

        public void RemoveSkill(int candidateId, int skillId)
        {
            var candidate = _candidateDbRepository.GetById(candidateId);
            var skill = _skillDbRepository.GetById(skillId);

            if (candidate.Skills.Any(s => s.Id == skillId)){
                candidate.Skills.Remove(skill);
                _candidateDbRepository.Update(candidate);
            }
            else
            {
                throw new Exception("Candidate does not have this skill.");
            }
        }
    }
}
