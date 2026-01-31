using Domain.Models;
using Domain.Services.Fees.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Fees
{
    //public class FeesRepository : IFeesRepository
    //{
    //    private readonly AppDbContext _context;

    //    public FeesRepository(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<bool> IsFeePaid(Guid studentId, int year, int month)
    //    {
    //        return await _context.FeePayments
    //            .AnyAsync(f => f.StudentId == studentId && f.Year == year && f.Month == month);
    //    }

    //    public async Task AddPayment(FeePayment payment)
    //    {
    //        _context.FeePayments.Add(payment);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task<List<FeePayment>> GetPaymentsByParent(Guid parentId)
    //    {
    //        return await _context.FeePayments
    //            .Where(f => f.ParentId == parentId)
    //            .ToListAsync();
    //    }

    //    public async Task<List<FeePayment>> GetAllPayments()
    //    {
    //        return await _context.FeePayments
    //            .Include(f => f.Student)
    //            .ToListAsync();
    //    }
    //}

    public class FeesRepository : IFeesRepository
    {
        private readonly AppDbContext _context;

        public FeesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsFeePaid(Guid studentId, int year, int month)
        {
            return await _context.FeePayments.AnyAsync(p =>
                p.StudentId == studentId &&
                p.Year == year &&
                p.Month == month);
        }

        public async Task AddPayment(FeePayment payment)
        {
            _context.FeePayments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FeePayment>> GetPaymentsByParent(Guid parentId)
        {
            return await _context.FeePayments
                .Include(p => p.Student)
                .Where(p => p.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<List<FeePayment>> GetAllPayments()
        {
            return await _context.FeePayments
                .Include(p => p.Student)
                .Include(p => p.Parent)
                .ToListAsync();
        }
    }
}