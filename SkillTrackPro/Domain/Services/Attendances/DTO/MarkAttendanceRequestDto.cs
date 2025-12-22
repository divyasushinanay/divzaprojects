using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Attendances.DTO
{
   public class MarkAttendanceRequstDto
    {
        public Guid CoachId { get; set; }
        public List<MarkAttendanceDto> AttendanceList { get; set; } = new();
    }
}
