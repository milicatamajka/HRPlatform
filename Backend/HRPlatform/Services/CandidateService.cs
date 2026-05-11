using AutoMapper;
using HRPlatform.Database.Repositories.Interfaces;
using HRPlatform.Dtos;
using HRPlatform.Mappers;
using HRPlatform.Models;
using HRPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Routing.Matching;

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

        public void Delete(int candidateId)
        {
            var candidate = _candidateDbRepository.GetById(candidateId);
            if (candidate == null)
            {
                throw new Exception("Candidate does not exist.");
            }
            _candidateDbRepository.Delete(candidate);
        }

        public List<CandidateDto> SearchByNameAndSkills(string name, List<int> skillIds)
        {
            List<Candidate> candidates;

            if (!string.IsNullOrEmpty(name) && skillIds != null && skillIds.Count > 0)
            {
                candidates = _candidateDbRepository.GetByNameAndSkills(name, skillIds);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                candidates = _candidateDbRepository.GetByName(name);
            }
            else if (skillIds != null && skillIds.Count > 0)
            {
                candidates = _candidateDbRepository.GetBySkills(skillIds);
            }
            else
            {
                candidates = _candidateDbRepository.GetAll();
            }
            
            return _mapper.Map<List<CandidateDto>>(candidates);
        }
    }
}
