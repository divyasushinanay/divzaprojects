using Domain.Models;
using Domain.Services.Auth;
using Domain.Services.Fees.Interface;

using Domain.Services.Parentz.DTO;
using Domain.Services.Parentz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Parentz
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _repo;

        public ParentService(IParentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Parent> CreateParentAsync(ParentRegisterDto dto)
        {
            var parent = new Parent
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };

            return await _repo.AddParentAsync( parent);
        }

        public async Task<IEnumerable<Parent>> GetAllParentsAsync()
        {
            return await _repo.GetAllParentsAsync();
        }


      




        public async Task<Parent?> GetParentByIdAsync(Guid id)
        {
            return await _repo.GetParentByIdAsync(id);
        }

        public async Task<bool> DeleteParentAsync(Guid id)
        {
            return await _repo.DeleteParentAsync(id);
        }

        public async Task<IEnumerable<Student>> GetStudentsByParentIdAsync(Guid parentId)
        {
            return await _repo.GetStudentsByParentIdAsync(parentId);
        }
    }
}
