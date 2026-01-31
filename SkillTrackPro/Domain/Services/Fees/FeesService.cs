using Domain.Enum;
using Domain.Models;
using Domain.Services.Fees.DTO;
using Domain.Services.Fees.Interface;
using Domain.Services.Studentz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees
{
    public class FeesService : IFeesService
    {
        private readonly IFeesRepository _feesRepo;
        private readonly IStudentRepository _studentRepo;

        public FeesService(IFeesRepository feesRepo, IStudentRepository studentRepo)
        {
            _feesRepo = feesRepo;
            _studentRepo = studentRepo;
        }

        // ================= PAY FEE =================
        public async Task PayFee(Guid parentId, PayFeeRequestDto dto)
        {
            var student = await _studentRepo.GetByIdAsync(dto.StudentId);

            if (student == null)
                throw new Exception("Student not found");

            if (student.ParentId != parentId)
                throw new UnauthorizedAccessException("Access denied");

            if (await _feesRepo.IsFeePaid(dto.StudentId, dto.Year, dto.Month))
                throw new Exception("Fee already paid for this month");

            decimal amount = student.SportCategory switch
            {
                SportCategory.Football => 2000,
                SportCategory.Cricket => 2500,
                SportCategory.Swimming => 3000,
                _ => 2000
            };

            var payment = new FeePayment
            {
                Id = Guid.NewGuid(),
                StudentId = student.Id,
                ParentId = parentId,
                Year = dto.Year,
                Month = dto.Month,
                Amount = amount,
                Status = PaymentStatus.Paid,
                PaidOn = DateTime.UtcNow
            };

            await _feesRepo.AddPayment(payment);
        }

        // ================= ADMIN – STUDENTS WITH DUES =================
        public async Task<List<DueStudentDto>> GetStudentsWithDues()
        {
            var students = await _studentRepo.GetAllAsync();
            var payments = await _feesRepo.GetAllPayments();

            var dues = new List<DueStudentDto>();

            foreach (var student in students)
            {
                var start = student.CreatedAt.Date;
                var now = DateTime.UtcNow.Date;

                for (var dt = start; dt <= now; dt = dt.AddMonths(1))
                {
                    bool paid = payments.Any(p =>
                        p.StudentId == student.Id &&
                        p.Year == dt.Year &&
                        p.Month == dt.Month);

                    if (!paid)
                    {
                        dues.Add(new DueStudentDto
                        {
                            StudentId = student.Id,
                            StudentName = student.FullName,
                            DueMonths = dt.Month
                        });
                    }
                }
            }

            return dues;
        }

        // ================= PARENT – PAYMENT HISTORY =================
        public async Task<List<ParentPaymentDto>> GetParentPayments(Guid parentId)
        {
            var payments = await _feesRepo.GetPaymentsByParent(parentId);

            return payments.Select(p => new ParentPaymentDto
            {
                Year = p.Year,
                Month = p.Month,
                Amount = p.Amount,
                PaidOn = p.PaidOn
            }).ToList();
        }
    }
}
