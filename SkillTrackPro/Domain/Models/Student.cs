using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   
    using Domain.Enum;

    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }

        public SportCategory SportCategory { get; set; }

        public CoachingSlot CoachingSlot { get; set; }

        public string? PhotoUrl { get; set; }

        public int ParentId { get; set; }
        public Parent? Parent { get; set; }
    }



}
