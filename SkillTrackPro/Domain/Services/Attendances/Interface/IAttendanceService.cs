using Domain.Services.Attendances.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Attendances.DTO;

namespace Domain.Services.Attendances.Interface
{
    public interface IAttendanceService
    {
        Task MarkAttendanceAsync(MarkAttendanceRequestDto request);

        Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByStudentAsync(Guid studentId, DateTime? from = null, DateTime? to = null);

        Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByCoachAsync(Guid coachId, DateTime? from = null, DateTime? to = null);

        Task<IEnumerable<AttendanceResponseDto>>
            GetAttendanceByParentAsync(Guid parentId, Guid studentId,
                                       DateTime? from = null, DateTime? to = null);
    }
}

