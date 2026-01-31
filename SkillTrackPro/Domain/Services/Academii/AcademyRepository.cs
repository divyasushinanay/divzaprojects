using Domain.Models;
using Domain.Services.Academii.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Academii
{
    public class AcademyRepository : IAcademyRepository
    {
        private readonly AppDbContext _context;

        public AcademyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Coach)
                .ToListAsync();
        }

        public async Task<List<Student>> GetApprovedStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Coach)
                .Where(s => s.IsApproved)
                .ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(Guid studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task<Coach?> GetCoachByIdAsync(Guid coachId)
        {
            return await _context.Coaches.FindAsync(coachId);
        }

        public async Task<Academy?> GetByUsernameAsync(string username)
        {
            return await _context.Academies
                .FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
