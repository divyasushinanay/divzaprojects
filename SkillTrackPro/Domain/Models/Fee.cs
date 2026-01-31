using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Fee
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public SportCategory SportCategory { get; set; }
        public CoachingSlot CoachingSlot { get; set; }

        public decimal MonthlyAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
