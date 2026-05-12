using System.ComponentModel.DataAnnotations;

namespace HRPlatform.Dtos
{
    public class SkillDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public SkillDto(string name)
        {
            Name = name;
        }
    }
}
