using Domain.Services.Coaches.DTO;
using Domain.Services.Coaches.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillTrackPro.API.Coach
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        // ---------------------------------------------------------
        // CREATE COACH
        // ---------------------------------------------------------
        [HttpPost("register")]
        public async Task<IActionResult> RegisterCoach([FromBody] CoachRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var coach = await _coachService.CreateCoachAsync(dto);

            return Ok(new
            {
                message = "Coach registered successfully",
                data = coach
            });
        }

        // ---------------------------------------------------------
        // GET ALL COACHES
        // ---------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAllCoaches()
        {
            var coaches = await _coachService.GetAllCoachesAsync();
            return Ok(coaches);
        }

        // ---------------------------------------------------------
        // GET COACH BY GUID
        // ---------------------------------------------------------
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCoachById(Guid id)
        {
            var coach = await _coachService.GetCoachByIdAsync(id);

            if (coach == null)
                return NotFound("Coach not found");

            return Ok(coach);
        }

        // ---------------------------------------------------------
        // DELETE COACH BY GUID
        // ---------------------------------------------------------
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCoach(Guid id)
        {
            var deleted = await _coachService.DeleteCoachAsync(id);

            if (!deleted)
                return NotFound("Coach not found");

            return Ok(new { message = "Coach deleted successfully" });
        }
    }
}
