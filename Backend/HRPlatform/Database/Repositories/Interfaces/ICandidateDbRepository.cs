using HRPlatform.Models;

namespace HRPlatform.Database.Repositories.Interfaces
{
    public interface ICandidateDbRepository
    {
        public Candidate Create(Candidate candidate);
        public Candidate GetById(int candidateId);
        public Candidate Update(Candidate candidate);
        public void Delete(Candidate candidate);
        public List<Candidate> GetAll();
        public List<Candidate> GetByName(string name);
        public List<Candidate> GetBySkills(List<int> skillIds);
        public List<Candidate> GetByNameAndSkills(string name, List<int> skillIds);
    }
}
