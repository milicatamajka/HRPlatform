namespace HRPlatform.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Candidate> Candidates { get; set; } = new List<Candidate>();

        public Skill() { }

        public Skill(string name)
        {
            Name = name;
        }
        public Skill(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
