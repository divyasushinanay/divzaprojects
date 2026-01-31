using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Academii.Dtos
{
    public class StudentAdminViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        public string? CoachName { get; set; }
    }
}
