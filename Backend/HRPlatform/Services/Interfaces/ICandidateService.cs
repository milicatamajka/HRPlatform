using HRPlatform.Models;
using HRPlatform.Dtos;

namespace HRPlatform.Services.Interfaces
{
    public interface ICandidateService
    {
        public CandidateDto Create(CandidateDto candidateDto);
        public void AddSkill(int candidateId, int skillId);
        public void RemoveSkill(int candidateId, int skillId);
    }
}
