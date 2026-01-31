using Domain.Models;
using Domain.Services.Attendances.DTO;
using Domain.Services.Attendances.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Attendances
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repo;

        public AttendanceService(IAttendanceRepository repo)
        {
            _repo = repo;
        }

        public async Task MarkAttendanceAsync(MarkAttendanceRequestDto request)
        {
            if (request.CoachId == Guid.Empty)
                throw new ArgumentException("CoachId is required");

            if (request.AttendanceList == null || !request.AttendanceList.Any())
                throw new ArgumentException("Attendance list cannot be empty");

            var today = DateTime.UtcNow.Date; // ✅ DATE ONLY

            foreach (var item in request.AttendanceList)
            {
                if (item.StudentId == Guid.Empty)
                    continue;

                var attendance = new Attendance
                {
                    StudentId = item.StudentId,   // ✅ from list item
                    CoachId = request.CoachId,    // ✅ from request
                    Date = today,                 // ✅ date only
                    IsPresent = item.IsPresent    // ✅ from list item
                };

                await _repo.AddAsync(attendance);
            }
        }


        // =====================================
        // 2️⃣ VIEW ATTENDANCE (STUDENT)
        // =====================================
        public async Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByStudentAsync(Guid studentId, DateTime? from = null, DateTime? to = null)
        {
            if (studentId == Guid.Empty)
                throw new ArgumentException("StudentId is required");

            var data = await _repo.GetByStudentAsync(studentId, from, to);

            return data.Select(a => new AttendanceResponseDto
            {
                StudentId = a.StudentId,
                StudentName = a.Student?.FullName ?? string.Empty,
                CoachId = a.CoachId,
                Date = a.Date.ToString("yyyy-MM-dd"),
                IsPresent = a.IsPresent
            });
        }

        // =====================================
        // 3️⃣ VIEW ATTENDANCE (COACH)
        // =====================================
        public async Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByCoachAsync(Guid coachId, DateTime? from = null, DateTime? to = null)
        {
            if (coachId == Guid.Empty)
                throw new ArgumentException("CoachId is required");

            var data = await _repo.GetByCoachAsync(coachId, from, to);

            return data.Select(a => new AttendanceResponseDto
            {
                StudentId = a.StudentId,
                StudentName = a.Student?.FullName ?? string.Empty,
                CoachId = a.CoachId,
                Date = a.Date.ToString("yyyy-MM-dd"),
                IsPresent = a.IsPresent
            });
        }

        // =====================================
        // 4️⃣ VIEW ATTENDANCE (PARENT)
        // =====================================
        public async Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByParentAsync(Guid parentId, Guid studentId,
                                       DateTime? from = null, DateTime? to = null)
        {
            if (parentId == Guid.Empty)
                throw new ArgumentException("ParentId is required");

            if (studentId == Guid.Empty)
                throw new ArgumentException("StudentId is required");

            // 🔐 Authorization check
            var student = await _repo.GetStudentByIdAsync(studentId);

            if (student == null || student.ParentId != parentId)
                throw new UnauthorizedAccessException("Access denied");

            var data = await _repo.GetByStudentAsync(studentId, from, to);

            return data.Select(a => new AttendanceResponseDto
            {
                StudentId = a.StudentId,
                StudentName = student.FullName,
                CoachId = a.CoachId,
                Date = a.Date.ToString("yyyy-MM-dd"),
                IsPresent = a.IsPresent
            });
        }

       
    }
}