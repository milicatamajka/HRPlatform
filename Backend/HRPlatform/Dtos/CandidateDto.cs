namespace HRPlatform.Dtos
{
    public class CandidateDto
    {
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CandidateDto(string name, DateOnly birthDate, string phoneNumber, string email)
        {
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
