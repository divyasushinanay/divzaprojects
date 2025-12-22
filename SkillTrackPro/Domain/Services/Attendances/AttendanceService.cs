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

        public async Task MarkAttendanceAsync(Guid coachId, IEnumerable<MarkAttendanceDto> list)
        {
            if (list == null) return;

            var today = DateTime.UtcNow.Date;

            foreach (var item in list)
            {
                // check existing
                var existing = await _repo.GetByStudentAndDateAsync(item.StudentId, today);
                if (existing != null)
                {
                    existing.IsPresent = item.IsPresent;
                    existing.CoachId = coachId; // optional: store who marked/updated
                    await _repo.UpdateAsync(existing);
                }
                else
                {
                    var attendance = new Attendance
                    {
                        StudentId = item.StudentId,
                        CoachId = coachId,
                        Date = today,
                        IsPresent = item.IsPresent
                    };

                    await _repo.AddAsync(attendance);
                }
            }
        }

        public async Task<IEnumerable<AttendanceResponseDto>> GetAttendanceByStudentAsync(Guid studentId, DateTime? from = null, DateTime? to = null)
        {
            var data = await _repo.GetByStudentAsync(studentId, from, to);
            return data.Select(a => new AttendanceResponseDto
            {
                StudentId = a.StudentId,
                StudentName = a.Student?.FullName, // may be null unless EF includes navigation
                CoachId = a.CoachId,
                Date = a.Date,
                IsPresent = a.IsPresent
            });
        }

        public async Task<IEnumerable<AttendanceResponseDto>> GetAttendanceByCoachAsync(Guid coachId, DateTime? from = null, DateTime? to = null)
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
