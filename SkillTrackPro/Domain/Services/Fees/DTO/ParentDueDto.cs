using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees.DTO
{
    public class ParentDueDto
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal DueAmount { get; set; }
    }
}
