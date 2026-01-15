using Domain.Models;
using Domain.Services.Fees.Interface;

using Domain.Services.Parentz.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Parentz
{
    public class ParentRepository : IParentRepository
    {
        private readonly AppDbContext _context;

        public ParentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Parent> AddParentAsync(Parent parent)
        {
            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();
            return parent;
        }

        public async Task<IEnumerable<Parent>> GetAllParentsAsync()
        {
            return await _context.Parents.ToListAsync();
        }

        public async Task<Parent?> GetParentByIdAsync(Guid id)
        {
            return await _context.Parents
                .Include(p => p.Students)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeleteParentAsync(Guid id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent == null) return false;

            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetStudentsByParentIdAsync(Guid parentId)
        {
            return await _context.Students
                .Where(s => s.ParentId == parentId)
                .ToListAsync();
        }
    }
}

