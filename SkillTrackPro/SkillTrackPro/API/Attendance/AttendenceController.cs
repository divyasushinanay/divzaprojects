
using Domain.Services.Attendances.DTO;
using Domain.Services.Attendances.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SkillTrackPro.API.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // requires JWT
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        [Authorize(Roles = "Coach")]
        [HttpPost("mark")]
        public async Task<IActionResult> MarkAttendance(
            [FromBody] List<MarkAttendanceDto> dto)
        {
            if (dto == null || !dto.Any())
                return BadRequest("No attendance provided.");

            // Get CoachId from JWT
            var coachIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (coachIdClaim == null)
                return Unauthorized("Coach not authenticated.");

            if (!Guid.TryParse(coachIdClaim.Value, out Guid coachId))
                return Unauthorized("Invalid coach token.");

            await _attendanceService.MarkAttendanceAsync(coachId, dto);

            return Ok(new
            {
                message = "Attendance marked successfully",
                date = DateTime.UtcNow.Date
            });
        }
    }
}
