using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Student.DTO
{
    public class StudentCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;
        public string BloodGroup { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public string SportCategory { get; set; } = string.Empty;
        public string CoachingSlot { get; set; } = string.Empty;

        public string? PhotoUrl { get; set; }

        public int ParentId { get; set; }
    }
}
