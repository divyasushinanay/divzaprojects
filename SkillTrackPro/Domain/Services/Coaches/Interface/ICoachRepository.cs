

using Domain.Models;

namespace Domain.Services.Coaches.Interface
{
   
        public interface ICoachRepository
        {
            Task<Coach> AddCoachAsync(Coach coach);
            Task<IEnumerable<Coach>> GetAllCoachesAsync();
            Task<Coach?> GetCoachByIdAsync(Guid id);
            Task<bool> DeleteCoachAsync(Guid id);
            Task<Coach?> GetCoachByEmailAsync(string email);
            Task<Coach> UpdateCoachAsync(Coach coach);
        
    }
    }

