using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
namespace Domain.Services.Attendances.DTO
{
    public class MarkAttendanceDto
    {
        public Guid StudentId { get; set; }
        public bool IsPresent { get; set; }
    }
}
