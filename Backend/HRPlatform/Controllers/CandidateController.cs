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
    }
}
