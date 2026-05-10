using AutoMapper;
using HRPlatform.Dtos;
using HRPlatform.Models;

namespace HRPlatform.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
        }
    }
}
