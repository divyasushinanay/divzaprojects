using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.Services.Attendances.Interface
{
    public interface IAttendanceRepository
    {
        Task<Attendance> AddAsync(Attendance attendance);
        Task<Attendance> UpdateAsync(Attendance attendance);
        Task<Attendance?> GetByStudentAndDateAsync(Guid studentId, DateTime date);
        Task<IEnumerable<Attendance>> GetByStudentAsync(Guid studentId, DateTime? from = null, DateTime? to = null);
        Task<IEnumerable<Attendance>> GetByCoachAsync(Guid coachId, DateTime? from = null, DateTime? to = null);
    }
}
