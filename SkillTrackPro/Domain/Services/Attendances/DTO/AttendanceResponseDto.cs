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
            public string StudentName { get; set; } = string.Empty;
            public Guid CoachId { get; set; }
            public string Date { get; set; }   // ✅ Date only
            public bool IsPresent { get; set; }
        }
    }

