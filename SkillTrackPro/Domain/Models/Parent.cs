using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Parent
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;

        // Relationship
        public ICollection<Student>? Students { get; set; }
  

        // OTP Login fields
        public string? OTP { get; set; }
        public DateTime? OTPExpiry { get; set; }
    }

}
