

//using Domain.Models;
//using Domain.Services.Coaches.DTO;
//using Domain.Services.Coaches.Interface;

//namespace Domain.Services.Coaches
//{
//    public class CoachService : ICoachService
//    {
//        private readonly ICoachRepository _repo;

//        public CoachService(ICoachRepository repo)
//        {
//            _repo = repo;
//        }

//        public async Task<Coach> CreateCoachAsync(CoachRegisterDto dto)
//        {
//            var coach = new Coach
//            {
//                Id = Guid.NewGuid(),
//                FullName = dto.FullName,
//                PhoneNumber = dto.PhoneNumber,
//                Email = dto.Email,
//                SportSpecialization = dto.SportSpecialization,
//                ExperienceYears = dto.ExperienceYears,
//                PhotoUrl = dto.PhotoUrl,
//                IsActive = true
//            };

//            return await _repo.AddCoachAsync(coach);
//        }

//        public async Task<IEnumerable<Coach>> GetAllCoachesAsync()
//        {
//            return await _repo.GetAllCoachesAsync();
//        }

//        public async Task<Coach?> GetCoachByIdAsync(Guid id)
//        {
//            return await _repo.GetCoachByIdAsync(id);
//        }

//        public async Task<bool> DeleteCoachAsync(Guid id)
//        {
//            return await _repo.DeleteCoachAsync(id);
//        }
//        public async Task<bool> SendOtpAsync(string email)
//        {
//            var coach = await _repo.GetCoachByEmailAsync(email);
//            if (coach == null) return false;

//            // generate 6-digit OTP
//            var otp = new Random().Next(100000, 999999).ToString();

//            coach.OTP = otp;
//            coach.OTPExpiry = DateTime.UtcNow.AddMinutes(5);

//            await _repo.UpdateCoachAsync(coach);

//            // send email
//            await _emailService.SendEmailAsync(coach.Email, "Your OTP Code", $"Your OTP is {otp}");

//            // send SMS (optional)
//            // await _smsService.SendSmsAsync(coach.PhoneNumber, $"Your OTP: {otp}");

//            return true;
//        }

//        public async Task<string?> VerifyOtpAsync(CoachVerifyOtpDto dto)
//        {
//            var coach = await _repo.GetCoachByEmailAsync(dto.Email);
//            if (coach == null) return null;

//            if (coach.OTP != dto.OTP || coach.OTPExpiry < DateTime.UtcNow)
//                return null;

//            // OTP is correct → generate JWT
//            return _jwtService.GenerateToken(coach);
//        }

//        public Task<string?> VerifyOtpAsync(VerifyOtpDto dto)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}



//using Domain.Models;
//using Domain.Services.Coaches.DTO;
//using Domain.Services.Coaches.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;



//namespace Domain.Services.Coaches
// public class CoachService : ICoachService
//{
//    private readonly ICoachRepository _repo;

//    public CoachService(ICoachRepository repo)
//    {
//        _repo = repo;
//    }

//    public async Task<Coach> CreateCoachAsync(CoachRegisterDto dto)
//    {
//        var coach = new Coach
//        {
//            FullName = dto.FullName,
//            PhoneNumber = dto.PhoneNumber,
//            Email = dto.Email,
//            SportSpecialization = dto.SportSpecialization,
//            ExperienceYears = dto.ExperienceYears,
//            PhotoUrl = dto.PhotoUrl,
//            IsActive = true
//        };

//        return await _repo.AddCoachAsync(coach);
//    }

//    public async Task<IEnumerable<Coach>> GetAllCoachesAsync()
//    {
//        return await _repo.GetAllCoachesAsync();
//    }

//    public async Task<Coach?> GetCoachByIdAsync(int id)
//    {
//        return await _repo.GetCoachByIdAsync(id);
//    }

//    public async Task<Coach?> UpdateCoachAsync(int id, CoachUpdateDto dto)
//    {
//        var coach = await _repo.GetCoachByIdAsync(id);
//        if (coach == null)
//            return null;

//        coach.FullName = dto.FullName;
//        coach.PhoneNumber = dto.PhoneNumber;
//        coach.Email = dto.Email;
//        coach.SportSpecialization = dto.SportSpecialization;
//        coach.ExperienceYears = dto.ExperienceYears;
//        coach.PhotoUrl = dto.PhotoUrl;

//        return await _repo.UpdateCoachAsync(coach);
//    }

//    public async Task<bool> DeleteCoachAsync(int id)
//    {
//        var coach = await _repo.GetCoachByIdAsync(id);
//        if (coach == null)
//            return false;

//        return await _repo.DeleteCoachAsync(coach);
//    }
//}
//}


using Domain.Models;
using Domain.Services.Coaches.DTO;
using Domain.Services.Coaches.Interface;

namespace Domain.Services.Coaches
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _repo;

        public CoachService(ICoachRepository repo)
        {
            _repo = repo;
        }

        public async Task<Coach> CreateCoachAsync(CoachRegisterDto dto)
        {
            var coach = new Coach
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                SportSpecialization = dto.SportSpecialization,
                ExperienceYears = dto.ExperienceYears,
                PhotoUrl = dto.PhotoUrl,
                IsActive = true
            };

            return await _repo.AddCoachAsync(coach);
        }

        public async Task<IEnumerable<Coach>> GetAllCoachesAsync()
        {
            return await _repo.GetAllCoachesAsync();
        }

        public async Task<Coach?> GetCoachByIdAsync(Guid id)
        {
            return await _repo.GetCoachByIdAsync(id);
        }

        public async Task<bool> DeleteCoachAsync(Guid id)
        {
            return await _repo.DeleteCoachAsync(id);
        }

      

      
    }
}
