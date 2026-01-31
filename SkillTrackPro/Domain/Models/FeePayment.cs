using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Enum;
namespace Domain.Models
{
    public class FeePayment
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid ParentId { get; set; }
        public Parent Parent { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime PaidOn { get; set; }
    }
}
