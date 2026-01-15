using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Parent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;   
        public string Address { get; set; } = string.Empty;      
        public DateTime? OTPExpiry { get; set; }
        public string OTP { get; set; } = string.Empty;
     

        public bool IsEmailVerified { get; set; }                  

        // Navigation
        public ICollection<Student>? Students { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


