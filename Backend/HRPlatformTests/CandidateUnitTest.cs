using AutoMapper;
using HRPlatform.Database.Repositories;
using HRPlatform.Database.Repositories.Interfaces;
using HRPlatform.Dtos;
using HRPlatform.Models;
using HRPlatform.Services;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlatformTests
{
    public class CandidateUnitTest
    {
        public Mock<ICandidateDbRepository> candidateRepository = new Mock<ICandidateDbRepository>();
        public Mock<ISkillDbRepository> skillRepository = new Mock<ISkillDbRepository>();
        public Mock<IMapper> mapper = new Mock<IMapper>();

        [Fact]
        public void Create_when_email_is_in_use()
        {
            var candidate = new Candidate("Pera Peric", DateOnly.Parse("1998-05-10"), "+381601234567", "peraperic98@gmail.com");
            var newCandidate = new CandidateDto("Petar Petrovic", DateOnly.Parse("1998-09-21"), "+381601234567", "peraperic98@gmail.com");
            var candidates = new List<Candidate>();
            candidates.Add(candidate);

            candidateRepository.Setup(sr => sr.GetAll()).Returns(candidates);
            mapper.Setup(m => m.Map<Candidate>(newCandidate)).Returns(new Candidate("Petar Petrovic", DateOnly.Parse("1998-09-21"), "+381601234567", "peraperic98@gmail.com"));

            var candidateService = new CandidateService(candidateRepository.Object, skillRepository.Object, mapper.Object);

            Should.Throw<Exception>(() => candidateService.Create(newCandidate));

        }

        [Fact]
        public void Create_when_date_is_in_the_future()
        {
            var candidate = new CandidateDto("Pera Peric", DateOnly.Parse("2030-05-10"), "+381601234567", "peraperic98@gmail.com");

            mapper.Setup(m => m.Map<Candidate>(candidate)).Returns(new Candidate("Pera Peric", DateOnly.Parse("2030-05-10"), "+381601234567", "peraperic98@gmail.com"));

            var candidateService = new CandidateService(candidateRepository.Object, skillRepository.Object, mapper.Object);

            Should.Throw<Exception>(() => candidateService.Create(candidate));

        }

        [Fact]
        public void Candidate_already_has_skill()
        {
            var candidate = new Candidate(1, "Pera Peric", DateOnly.Parse("1998-05-10"), "+381601234567", "peraperic98@gmail.com");
            var skill = new Skill(1, "#C");
            candidate.Skills.Add(skill);

            candidateRepository.Setup(cr => cr.GetById(1)).Returns(candidate);
            skillRepository.Setup(sr => sr.GetById(1)).Returns(skill);

            var candidateService = new CandidateService(candidateRepository.Object, skillRepository.Object, mapper.Object);

            Should.Throw<Exception>(() => candidateService.AddSkill(candidate.Id, skill.Id));
        }
    }
}
