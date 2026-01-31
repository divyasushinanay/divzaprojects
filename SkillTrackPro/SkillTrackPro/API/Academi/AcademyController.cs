using Domain.Services.Academii.Dtos;
using Domain.Services.Academii.Interface;
using Domain.Services.Auth;
using Domain.Services.Coaches.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillTrackPro.API.Academy
{
    [ApiController]
    [Route("api/academy")]
    public class AcademyController : ControllerBase
    {

        private readonly IAcademyService _academyService;
        private readonly IAuthService _authService;
        private readonly ICoachService _coachService;

        public AcademyController(
            IAcademyService academyService,
            IAuthService authService,
            ICoachService coachService
        )
        {
            _academyService = academyService;
            _authService = authService;
            _coachService = coachService;
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _academyService.GetAllStudents());
        }

        [HttpGet("coaches")]
        public async Task<IActionResult> GetAllCoaches()
        {
            var coaches = await _coachService.GetAllCoachesAsync();
            return Ok(coaches);
        }

        [HttpPost("approve-student")]
        public async Task<IActionResult> ApproveStudent([FromBody] StudentApprovalDto dto)
        {
            await _academyService.ApproveStudent(dto);
            return Ok("Student approval updated");
        }

        [HttpPost("assign-coach")]
        public async Task<IActionResult> AssignCoach([FromBody] AssignCoachDto dto)
        {
            await _academyService.AssignCoach(dto);
            return Ok("Coach assigned successfully");
        }


        [HttpGet("approved-students")]
        public async Task<IActionResult> GetApprovedStudents()
        {
            return Ok(await _academyService.GetApprovedStudents());
        }

        [HttpPost("approve-coach/{coachId}")]
        public async Task<IActionResult> ApproveCoach(Guid coachId)
        {
            var result = await _coachService.ApproveCoachAsync(coachId);
            if (!result)
                return NotFound("Coach not found");

            return Ok("Coach approved successfully");
        }

        [HttpGet("approved-coaches")]
        public async Task<IActionResult> GetApprovedCoaches()
        {
            return Ok(await _coachService.GetApprovedCoachesAsync());
        }
    }
}
