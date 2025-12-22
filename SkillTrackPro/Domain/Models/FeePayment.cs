using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FeePayment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Mode { get; set; } = string.Empty; // UPI, Cash, Card

        public string Status { get; set; } = "Paid";
    }

}
