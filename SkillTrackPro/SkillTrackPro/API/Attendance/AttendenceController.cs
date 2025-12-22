
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
    [Authorize] // requires JWT
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // Mark multiple students (coachId taken from token)
        [HttpPost("mark")]
        public async Task<IActionResult> MarkAttendance([FromBody] IEnumerable<MarkAttendanceDto> dto)
        {
            if (dto == null || !dto.Any()) return BadRequest("No attendance provided.");

            var coachIdClaim = User.FindFirst("id") ?? User.FindFirst(ClaimTypes.NameIdentifier);
            if (coachIdClaim == null) return Unauthorized();

            if (!Guid.TryParse(coachIdClaim.Value, out var coachId))
                return Unauthorized("Invalid token coach id.");

            await _attendanceService.MarkAttendanceAsync(coachId, dto);
            return Ok(new { message = "Attendance recorded" });
        }

        // Get attendance for a student (optional from/to query yyyy-MM-dd)
        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetStudentAttendance(Guid studentId, [FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null)
        {
            var result = await _attendanceService.GetAttendanceByStudentAsync(studentId, from, to);
            return Ok(result);
        }

        // Get attendance for coach (optional from/to)
        [HttpGet("coach/{coachId}")]
        public async Task<IActionResult> GetCoachAttendance(Guid coachId, [FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null)
        {
            var result = await _attendanceService.GetAttendanceByCoachAsync(coachId, from, to);
            return Ok(result);
        }
    }
}
