
using Domain.Services.Attendances.DTO;
using Domain.Services.Attendances.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SkillTrackPro.API.Attendance
{
    [ApiController]
    [Route("api/attendance")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // =====================================
        // 1️⃣ COACH → MARK ATTENDANCE
        // =====================================
        [HttpPost("mark")]
        public async Task<IActionResult> MarkAttendance(
        [FromBody] MarkAttendanceRequestDto request)
        {
            await _attendanceService.MarkAttendanceAsync(request);
            return Ok("Attendance marked successfully");
        }

        // =====================================
        // 2️⃣ STUDENT → VIEW OWN ATTENDANCE
        // =====================================
        [Authorize(Roles = "Student")]
        [HttpGet("student")]
        public async Task<IActionResult> GetMyAttendance(
            DateTime? from,
            DateTime? to)
        {
            var studentId = GetUserId();

            var result = await _attendanceService
                .GetAttendanceByStudentAsync(studentId, from, to);

            return Ok(result);
        }

        // =====================================
        // 3️⃣ COACH → VIEW STUDENT ATTENDANCE
        // =====================================
        [Authorize(Roles = "Coach")]
        [HttpGet("coach/{studentId}")]
        public async Task<IActionResult> GetStudentAttendanceByCoach(
            Guid studentId,
            DateTime? from,
            DateTime? to)
        {
            var result = await _attendanceService
                .GetAttendanceByStudentAsync(studentId, from, to);

            return Ok(result);
        }

        // =====================================
        // 4️⃣ PARENT → VIEW CHILD ATTENDANCE
        // =====================================
        [Authorize(Roles = "Parent")]
        [HttpGet("parent/{studentId}")]
        public async Task<IActionResult> GetAttendanceByParent(
    Guid studentId,
    DateTime? from,
    DateTime? to)
        {
            var result = await _attendanceService
                .GetAttendanceByStudentAsync(
                    studentId,
                    from?.Date,
                    to?.Date);

            return Ok(result);
        }

        // =====================================
        // 🔐 GET LOGGED-IN USER ID (JWT)
        // =====================================
        private Guid GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User not authenticated");

            return Guid.Parse(userId);
        }
    }
}
