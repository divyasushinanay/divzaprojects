//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Domain.Models;

//namespace Domain.Services.Coaches.Interface
//{
//    public interface ICoachRepository
//    {
//    }
//}

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

