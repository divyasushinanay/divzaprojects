
using Domain.Services.Parentz.DTO;
using Domain.Services.Parentz.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillTrackPro.API.Parent
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        // 1️⃣ Create Parent
        [HttpPost]
        public async Task<IActionResult> CreateParent([FromBody] ParentRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parent = await _parentService.CreateParentAsync(dto);
            return Ok(parent);
        }

        // 2️⃣ Get All Parents
        [HttpGet]
        public async Task<IActionResult> GetAllParents()
        {
            var parents = await _parentService.GetAllParentsAsync();
            return Ok(parents);
        }

        // 3️⃣ Get Parent By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentById(Guid id)
        {
            var parent = await _parentService.GetParentByIdAsync(id);

            if (parent == null)
                return NotFound("Parent not found");

            return Ok(parent);
        }

        // 4️⃣ Delete Parent
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(Guid id)
        {
            var result = await _parentService.DeleteParentAsync(id);

            if (!result)
                return NotFound("Parent not found");

            return Ok("Parent deleted successfully");
        }

        // 5️⃣ Get Students By Parent Id
        [HttpGet("{parentId}/students")]
        public async Task<IActionResult> GetStudentsByParentId(Guid parentId)
        {
            var students = await _parentService.GetStudentsByParentIdAsync(parentId);
            return Ok(students);
        }
    }
}
