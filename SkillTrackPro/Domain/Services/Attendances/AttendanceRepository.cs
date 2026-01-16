using Domain.Models;
using Domain.Services.Attendances.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Attendances
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            _context.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAsync(Attendance attendance)
        {
            _context.Update(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance?> GetByStudentAndDateAsync(Guid studentId, DateTime date)
        {
            var d = date.Date;
            return await _context.Attendances
                .FirstOrDefaultAsync(a => a.StudentId == studentId && a.Date == d);
        }

        public async Task<IEnumerable<Attendance>> GetByStudentAsync(Guid studentId, DateTime? from = null, DateTime? to = null)
        {
            var q = _context.Attendances
                .Where(a => a.StudentId == studentId)
                .AsQueryable();

            if (from.HasValue) q = q.Where(a => a.Date >= from.Value.Date);
            if (to.HasValue) q = q.Where(a => a.Date <= to.Value.Date);

            return await q.ToListAsync();
        }

        public async Task<bool> StudentExistsAsync(Guid studentId)
        {
            return await _context.Students.AnyAsync(s => s.Id == studentId);
        }

        public async Task<IEnumerable<Attendance>> GetByCoachAsync(Guid coachId, DateTime? from = null, DateTime? to = null)
        {
            var q = _context.Attendances
                .Where(a => a.CoachId == coachId)
                .AsQueryable();

            if (from.HasValue) q = q.Where(a => a.Date >= from.Value.Date);
            if (to.HasValue) q = q.Where(a => a.Date <= to.Value.Date);

            return await q.ToListAsync();
        }
    }
}
