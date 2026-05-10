using HRPlatform.Models;

namespace HRPlatform.Database.Repositories.Interfaces
{
    public interface ICandidateDbRepository
    {
        public Candidate Create(Candidate candidate);
    }
}
