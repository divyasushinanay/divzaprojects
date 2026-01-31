using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees.DTO
{
    public class DueStudentDto
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }

        public string ParentEmail { get; set; }

        public int DueMonths { get; set; }
        public decimal DueAmount { get; set; }
    }
}
