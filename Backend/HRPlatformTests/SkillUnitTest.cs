using Xunit;
using Moq;
using HRPlatform.Database.Repositories.Interfaces;
using AutoMapper;
using HRPlatform.Models;
using HRPlatform.Services;
using HRPlatform.Dtos;
using Shouldly;

namespace HRPlatformTests
{
    public class SkillUnitTest
    {
        public Mock<ISkillDbRepository> skillRepository = new Mock<ISkillDbRepository>();
        public Mock<IMapper> mapper = new Mock<IMapper>();

        [Fact]
        public void Create_when_name_is_in_use()
        {
            var skill = new Skill("#C");
            var newSkill = new SkillDto("#c");
            var skills = new List<Skill>();
            skills.Add(skill);

            skillRepository.Setup(sr => sr.GetAll()).Returns(skills);
            mapper.Setup(m => m.Map<Skill>(newSkill)).Returns(new Skill("#c"));

            var skillService = new SkillService(skillRepository.Object, mapper.Object);

            Should.Throw<Exception>(() => skillService.Create(newSkill));

        }
    }
}