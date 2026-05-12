using HRPlatform.Dtos;
using HRPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        public ActionResult<SkillDto> Create([FromBody] SkillDto skillDto)
        {
            try
            {
                var result = _skillService.Create(skillDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpGet]
        public ActionResult<List<SkillDto>> GetAll()
        {
            try
            {
                var result = _skillService.GetAll();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
