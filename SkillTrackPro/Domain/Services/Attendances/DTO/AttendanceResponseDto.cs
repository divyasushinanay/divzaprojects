using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Attendances.DTO
{
    public class AttendanceResponseDto
    {
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public Guid CoachId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
