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
            try
            {
                var result = _candidateService.Create(candidateDto);
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{candidateId}/add-skill/{skillId}")]
        public IActionResult AddSkill(int candidateId, int skillId)
        {
            try
            {
                _candidateService.AddSkill(candidateId, skillId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpDelete("{candidateId}/delete-skill/{skillId}")]
        public IActionResult RemoveSkill(int candidateId, int skillId)
        {
            try
            {
                _candidateService.RemoveSkill(candidateId, skillId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{candidateId}")]
        public IActionResult Delete(int candidateId)
        {
            try
            {
                _candidateService.Delete(candidateId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public ActionResult<List<CandidateDto>> SearchByNameAndSkill([FromQuery]string? name, [FromQuery]List<int>? skillIds)
        {
            try
            {
                var result = _candidateService.SearchByNameAndSkills(name, skillIds);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
