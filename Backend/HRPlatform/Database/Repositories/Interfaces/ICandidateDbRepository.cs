using HRPlatform.Models;

namespace HRPlatform.Database.Repositories.Interfaces
{
    public interface ICandidateDbRepository
    {
        public Candidate Create(Candidate candidate);
        public Candidate GetById(int id);
        public Candidate Update(Candidate candidate);
    }
}
