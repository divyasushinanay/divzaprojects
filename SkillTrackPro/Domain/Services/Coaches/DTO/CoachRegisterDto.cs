using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Coaches.DTO
{
  
        public class CoachRegisterDto
        {
            public string FullName { get; set; } = string.Empty;
            public string PhoneNumber { get; set; } = string.Empty;
            public string? Email { get; set; }
            public string SportSpecialization { get; set; } = string.Empty;
            public int ExperienceYears { get; set; }
            public string? PhotoUrl { get; set; }
        }
    }

