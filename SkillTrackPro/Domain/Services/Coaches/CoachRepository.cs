//using Domain.Services.Attendance.Interface;
//using Domain.Services.Coaches.DTO;
//using Domain.Services.Coaches.Interface;

//namespace Domain.Services.CoachPage
//{
//    internal class CoachRepository : ICoachRepository
//    {
//    }
//}

using Domain.Models;
using Domain.Services.Coaches.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Coaches
{
    public class CoachRepository : ICoachRepository
    {
        private readonly AppDbContext _context;

        public CoachRepository(AppDbContext db)
        {
            _context = db;
        }

        public async Task<Coach> AddCoachAsync(Coach coach)
        {
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();
            return coach;
        }

        public async Task<Coach?> GetCoachByIdAsync(Guid id)
        {
            return await _context.Coaches.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Coach>> GetAllCoachesAsync()
        {
            return await _context.Coaches.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteCoachAsync(Guid id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null) return false;

            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<Coach?> GetCoachByEmailAsync(string email)
        {
            return await _context.Coaches.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Coach> UpdateCoachAsync(Coach coach)
        {
            _context.Coaches.Update(coach);
            await _context.SaveChangesAsync();
            return coach;
        }
    }
}
