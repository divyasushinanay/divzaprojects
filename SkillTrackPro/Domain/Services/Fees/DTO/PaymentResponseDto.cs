using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees.DTO
{
    public class PaymentResponseDto
    {
        public string StudentName { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidOn { get; set; }
    }
}
