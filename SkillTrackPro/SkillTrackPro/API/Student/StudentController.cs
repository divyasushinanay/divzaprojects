
using Domain.Services.Studentz.DTO;
using Domain.Services.Studentz.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillTrackPro.API.Student
{
    [ApiController]
    [Route("api/[controller]")]
 // optional – remove if students can be public
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // ---------------- CREATE STUDENT ----------------
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentId = await _studentService.CreateStudentAsync(dto);

            return Ok(new
            {
                message = "Student created successfully",
                studentId = studentId
            });
        }

        // ---------------- GET ALL STUDENTS ----------------
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // ---------------- GET STUDENT BY ID ----------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // ---------------- UPDATE STUDENT ----------------
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] StudentUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _studentService.UpdateStudentAsync(id, dto);

            if (!updated)
                return NotFound("Student not found");

            return Ok(new { message = "Student updated successfully" });
        }

        // ---------------- DELETE STUDENT ----------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var deleted = await _studentService.DeleteStudentAsync(id);

            if (!deleted)
                return NotFound("Student not found");

            return Ok(new { message = "Student deleted successfully" });
        }
    }
}
