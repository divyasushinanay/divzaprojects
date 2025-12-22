using Domain.Models;
using Domain.Services.Studentz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Studentz.Interface
{
    public interface IStudentService
    {
        Task<Guid> CreateStudentAsync(StudentCreateDto dto);

        Task<IEnumerable<StudentCreateDto>> GetAllStudentsAsync();

        Task<StudentCreateDto?> GetStudentByIdAsync(Guid id);

        Task<bool> UpdateStudentAsync(Guid id, StudentUpdateDto dto);

        Task<bool> DeleteStudentAsync(Guid id);
    }
}
