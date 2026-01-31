using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Academii.Dtos
{
    public class StudentApprovalDto
    {
        public Guid StudentId { get; set; }
        public bool Approve { get; set; }
    }
}
