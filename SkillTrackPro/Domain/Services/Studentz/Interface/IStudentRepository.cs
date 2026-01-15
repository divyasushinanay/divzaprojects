using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
namespace Domain.Services.Studentz.Interface
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student student);
        Task<List<Student>> GetByParentIdAsync(Guid parentId);
    }
}
