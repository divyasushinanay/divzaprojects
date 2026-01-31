using Domain.Services.Academii.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Academii.Interface
{
    public interface IAcademyService
    {
        Task<List<StudentAdminViewDto>> GetAllStudents();
        Task ApproveStudent(StudentApprovalDto dto);
        Task AssignCoach(AssignCoachDto dto);
        Task<List<StudentAdminViewDto>> GetApprovedStudents();

    }
}
