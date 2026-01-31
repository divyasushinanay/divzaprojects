//using Domain.Models;                     // ← VERY IMPORTANT
//using Domain.Services.Coaches.DTO;
//using Domain.Services.Coaches.Interface;

//namespace Domain.Services.Coaches
//{
//    public interface ICoachService
//    {
//        Task<Coach> CreateCoachAsync(CoachRegisterDto dto);
//        Task<Coach?> GetCoachByIdAsync(int id);
//        Task<IEnumerable<Coach>> GetAllCoachesAsync();
//        //Task<Coach?> UpdateCoachAsync(int id, CoachUpdateDto dto);
//        Task<bool> DeleteCoachAsync(int id);
//    }

//}

using Domain.Models;
using Domain.Services.Coaches.DTO;

namespace Domain.Services.Coaches.Interface
{
         public interface ICoachService
            {
                Task<Coach> CreateCoachAsync(CoachRegisterDto dto);
                Task<IEnumerable<Coach>> GetAllCoachesAsync();
                Task<Coach?> GetCoachByIdAsync(Guid id);
                Task<bool> DeleteCoachAsync(Guid id);
               Task<IEnumerable<Coach>> GetApprovedCoachesAsync();
               Task<bool> ApproveCoachAsync(Guid coachId);
        // Task<bool> SendOtpAsync(string email);
        //Task<string?> VerifyOtpAsync(VerifyOtpDto dto);
    }
        }
