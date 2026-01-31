using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Parentz.Interface
{

    public interface IParentRepository
    {
        Task<Parent> AddParentAsync(Parent parent);
        Task<IEnumerable<Parent>> GetAllParentsAsync();
        Task<Parent?> GetParentByIdAsync(Guid id);
        Task<bool> DeleteParentAsync(Guid id);
        Task<IEnumerable<Student>> GetStudentsByParentIdAsync(Guid parentId);
    }

}

