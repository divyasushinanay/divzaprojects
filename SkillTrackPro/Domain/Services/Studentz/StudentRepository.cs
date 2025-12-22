using Domain.Models;
using Domain.Services.Studentz.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Studentz
{
   
        public class StudentRepository : IStudentRepository
        {
            private readonly AppDbContext _context;

            public StudentRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Student> AddAsync(Student student)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return student;
            }

            public async Task<IEnumerable<Student>> GetAllAsync()
            {
                return await _context.Students
                    .Include(s => s.Parent)
                    .ToListAsync();
            }

            public async Task<Student?> GetByIdAsync(Guid id)
            {
                return await _context.Students
                    .Include(s => s.Parent)
                    .FirstOrDefaultAsync(s => s.Id == id);
            }

            public async Task UpdateAsync(Student student)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(Student student)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
