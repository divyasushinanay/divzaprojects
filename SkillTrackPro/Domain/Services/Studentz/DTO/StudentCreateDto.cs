using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Studentz.DTO
{
    public class StudentCreateDto
    {
       
            public string FullName { get; set; } = string.Empty;
            public int Age { get; set; }

            public Gender Gender { get; set; }
            public BloodGroup BloodGroup { get; set; }
            public SportCategory SportCategory { get; set; }
            public CoachingSlot CoachingSlot { get; set; }

            public DateTime DateOfBirth { get; set; }
            public double Height { get; set; }
            public double Weight { get; set; }

            public Guid ParentId { get; set; }   
            public string? PhotoUrl { get; set; }
    }
    }
