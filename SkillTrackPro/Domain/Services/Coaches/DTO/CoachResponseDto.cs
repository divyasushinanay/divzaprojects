using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Coaches.DTO
{
    public class CoachResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Experience { get; set; }
        public string SportCategory { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
