using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Coaches.DTO
{
    public class CoachProfileResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Qualification { get; set; }
        public string? Experience { get; set; }
        public string? ProfileImage { get; set; }
    }

}
