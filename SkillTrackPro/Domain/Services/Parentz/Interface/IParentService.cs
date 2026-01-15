using Domain.Models;
using Domain.Services.Coaches.DTO;
using Domain.Services.Parentz.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Parentz.Interface
{
    public interface IParentService
    {
        Task<Parent> CreateParentAsync(ParentRegisterDto dto);
        Task<IEnumerable<Parent>> GetAllParentsAsync();
        Task<Parent?> GetParentByIdAsync(Guid id);
        Task<bool> DeleteParentAsync(Guid id);
        Task<IEnumerable<Student>> GetStudentsByParentIdAsync(Guid parentId);
    }
}
