using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees.DTO
{
    
        public class PayFeeRequestDto
        {
            public Guid StudentId { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
        }
    }

