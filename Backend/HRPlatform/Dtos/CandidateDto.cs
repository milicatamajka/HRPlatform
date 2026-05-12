using System.ComponentModel.DataAnnotations;

namespace HRPlatform.Dtos
{
    public class CandidateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
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
