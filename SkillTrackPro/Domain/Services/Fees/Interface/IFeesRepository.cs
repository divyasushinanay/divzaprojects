using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees.Interface
{
    public interface IFeesRepository
    {
        Task<bool> IsFeePaid(Guid studentId, int year, int month);
        Task AddPayment(FeePayment payment);
        Task<List<FeePayment>> GetPaymentsByParent(Guid parentId);
        Task<List<FeePayment>> GetAllPayments();
    }
}
