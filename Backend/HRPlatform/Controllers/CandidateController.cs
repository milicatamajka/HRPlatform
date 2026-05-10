using HRPlatform.Dtos;
using HRPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService) 
        { 
            _candidateService = candidateService;
        }

        [HttpPost]
        public ActionResult<CandidateDto> Create([FromBody] CandidateDto candidateDto)
        {
            var result = _candidateService.Create(candidateDto);
            return Ok(result);
        }

        [HttpPut("{candidateId}/add-skill/{skillId}")]
        public IActionResult AddSkill(int candidateId, int skillId)
        {
            _candidateService.AddSkill(candidateId, skillId);
            return Ok();
        }

        [HttpDelete("{candidateId}/delete-skill/{skillId}")]
        public IActionResult RemoveSkill(int candidateId, int skillId)
        {
            _candidateService.RemoveSkill(candidateId, skillId);
            return Ok();
        }
    }
}
