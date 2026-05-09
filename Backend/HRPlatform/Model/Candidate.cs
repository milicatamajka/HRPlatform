namespace HRPlatform.Model
{
    public class Candidate
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();

        public Candidate() { }

        public Candidate(int id, string name, DateOnly birthDate, string phoneNumber, string email)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
