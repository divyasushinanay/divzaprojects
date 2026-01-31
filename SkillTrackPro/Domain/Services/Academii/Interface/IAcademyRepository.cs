using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Academii.Interface
{
    public interface IAcademyRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<List<Student>> GetApprovedStudentsAsync();   // ✅ ADD THIS
        Task<Student?> GetStudentByIdAsync(Guid studentId);
        Task<Coach?> GetCoachByIdAsync(Guid coachId);
        Task<Academy?> GetByUsernameAsync(string username);
        Task SaveAsync();
    }
}
