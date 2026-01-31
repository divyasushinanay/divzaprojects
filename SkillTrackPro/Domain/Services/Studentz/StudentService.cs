using AutoMapper;
using Domain.Models;

using Domain.Services.Studentz.DTO;
using Domain.Services.Studentz.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Studentz
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // CREATE
        public async Task<Guid> CreateStudentAsync(StudentCreateDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            student.Id = Guid.NewGuid();

            await _repository.AddAsync(student);
            return student.Id;
        }

        // GET ALL
        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
        {
            var students = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentResponseDto>>(students);
        }

        // GET BY ID
        public async Task<StudentResponseDto?> GetStudentByIdAsync(Guid id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return null;

            return _mapper.Map<StudentResponseDto>(student);
        }

        // UPDATE
        public async Task<bool> UpdateStudentAsync(Guid id, StudentUpdateDto dto)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            _mapper.Map(dto, student); // updates allowed fields only
            await _repository.UpdateAsync(student);

            return true;
        }

        // DELETE
        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            await _repository.DeleteAsync(student);
            return true;
        }

        public async Task<List<StudentResponseDto>> GetStudentsByParentIdAsync(Guid parentId)
        {
            var students = await _repository.GetByParentIdAsync(parentId);
            return _mapper.Map<List<StudentResponseDto>>(students);
        }

       
    }
}