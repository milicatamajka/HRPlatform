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
        private readonly IMapper _mapper;
        public CandidateService(ICandidateDbRepository candidateDbRepository, IMapper mapper) 
        {
            _candidateDbRepository = candidateDbRepository;
            _mapper = mapper;
        }

        public CandidateDto Create(CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);
            _candidateDbRepository.Create(candidate);
            return _mapper.Map<CandidateDto>(candidate);
        }
    }
}
