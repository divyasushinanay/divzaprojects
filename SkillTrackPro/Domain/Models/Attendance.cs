using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class Attendance
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid StudentId { get; set; }
        public Guid CoachId { get; set; }

        // store date only (time component normalized)
        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }

        // navigation (optional)
        public Student? Student { get; set; }
        public Coach? Coach { get; set; }
    }

}
