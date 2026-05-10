using HRPlatform.Models;
using HRPlatform.Dtos;

namespace HRPlatform.Services.Interfaces
{
    public interface ICandidateService
    {
        public CandidateDto Create(CandidateDto candidateDto);
    }
}
