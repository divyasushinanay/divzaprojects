

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
                IsApproved = false   // 👈 waiting for academy approval
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

        public async Task<bool> ApproveCoachAsync(Guid coachId)
        {
            var coach = await _repo.GetCoachByIdAsync(coachId);
            if (coach == null) return false;

            coach.IsApproved = true;
            await _repo.UpdateCoachAsync(coach);
            return true;
        }

        public async Task<IEnumerable<Coach>> GetApprovedCoachesAsync()
        {
            return await _repo.GetApprovedCoachesAsync();
        }


    }
}
