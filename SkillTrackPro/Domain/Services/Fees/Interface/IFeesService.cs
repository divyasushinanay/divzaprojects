using Domain.Services.Fees.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees.Interface
{
   
        public interface IFeesService
        {
            Task PayFee(Guid parentId, PayFeeRequestDto dto);

            Task<List<ParentPaymentDto>> GetParentPayments(Guid parentId);

            Task<List<DueStudentDto>> GetStudentsWithDues();

            //Task<List<AdminPaymentDto>> GetAllPaymentsForAdmin(); // ✅ ADD THIS
        }
    }

