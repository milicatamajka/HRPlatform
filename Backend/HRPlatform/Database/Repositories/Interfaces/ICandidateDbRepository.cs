using HRPlatform.Models;

namespace HRPlatform.Database.Repositories.Interfaces
{
    public interface ICandidateDbRepository
    {
        public Candidate Create(Candidate candidate);
        public Candidate GetById(int candidateId);
        public Candidate Update(Candidate candidate);
        public void Delete(Candidate candidate);
    }
}
