using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PerformanceReview
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CoachId { get; set; }
        public Coach? Coach { get; set; }

        public string ReviewText { get; set; } = string.Empty;

        public string Rating { get; set; } = string.Empty; // Good, Excellent, Needs Improvement

        public DateTime Date { get; set; }
    }

}
