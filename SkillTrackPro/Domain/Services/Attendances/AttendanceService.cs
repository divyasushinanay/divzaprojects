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

        // ===============================
        // 1️⃣ MARK ATTENDANCE (BY COACH)
        // ===============================
        public async Task MarkAttendanceAsync(Guid coachId, IEnumerable<MarkAttendanceDto> list)
        {
            if (coachId == Guid.Empty)
                throw new ArgumentException("Invalid coach");

            if (list == null || !list.Any())
                return;

            var today = DateTime.UtcNow.Date;

            foreach (var item in list)
            {
                var existing = await _repo.GetByStudentAndDateAsync(item.StudentId, today);

                if (existing != null)
                {
                    existing.IsPresent = item.IsPresent;
                    existing.CoachId = coachId;
                    await _repo.UpdateAsync(existing);
                }
                else
                {
                    await _repo.AddAsync(new Attendance
                    {
                        StudentId = item.StudentId,
                        CoachId = coachId,
                        Date = today,
                        IsPresent = item.IsPresent
                    });
                }
            }
        }

        // =====================================
        // 2️⃣ GET ATTENDANCE BY STUDENT
        // =====================================
        public async Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByStudentAsync(Guid studentId, DateTime? from = null, DateTime? to = null)
        {
            var data = await _repo.GetByStudentAsync(studentId, from, to);

            return data.Select(a => new AttendanceResponseDto
            {
                StudentId = a.StudentId,
                StudentName = a.Student?.FullName,
                CoachId = a.CoachId,
                Date = a.Date,
                IsPresent = a.IsPresent
            });
        }

        // =====================================
        // 3️⃣ GET ATTENDANCE BY COACH
        // =====================================
        public async Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByCoachAsync(Guid coachId, DateTime? from = null, DateTime? to = null)
        {
            var data = await _repo.GetByCoachAsync(coachId, from, to);

            return data.Select(a => new AttendanceResponseDto
            {
                StudentId = a.StudentId,
                StudentName = a.Student?.FullName,
                CoachId = a.CoachId,
                Date = a.Date,
                IsPresent = a.IsPresent
            });
        }
    }
}