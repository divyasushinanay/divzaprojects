using Domain.Models;
using Domain.Services.Academii.Dtos;
using Domain.Services.Academii.Interface;
using Domain.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Academii
{
    //public class AcademyService : IAcademyService
    //{
    //    private readonly IAcademyRepository _academyRepo;

    //    public AcademyService(IAcademyRepository academyRepo)
    //    {
    //        _academyRepo = academyRepo;
    //    }

    //    public async Task<List<StudentAdminViewDto>> GetAllStudents()
    //    {
    //        var students = await _academyRepo.GetAllStudentsAsync();

    //        return students.Select(s => new StudentAdminViewDto
    //        {
    //            Id = s.Id,
    //            Name = s.FullName,
    //            IsApproved = s.IsApproved,
    //            CoachName = s.Coach != null ? s.Coach.FullName : null
    //        }).ToList();
    //    }

    //    public async Task ApproveStudent(StudentApprovalDto dto)
    //    {
    //        var student = await _academyRepo.GetStudentByIdAsync(dto.StudentId);

    //        if (student == null)
    //            throw new Exception("Student not found");

    //        student.IsApproved = dto.Approve;
    //        await _academyRepo.SaveAsync();
    //    }

    //    public async Task AssignCoach(AssignCoachDto dto)
    //    {
    //        var student = await _academyRepo.GetStudentByIdAsync(dto.StudentId);
    //        var coach = await _academyRepo.GetCoachByIdAsync(dto.CoachId);

    //        if (student == null)
    //            throw new Exception("Student not found");

    //        if (!student.IsApproved)
    //            throw new Exception("Student not approved");

    //        if (coach == null)
    //            throw new Exception("Coach not found");

    //        student.CoachId = coach.Id;
    //        await _academyRepo.SaveAsync();
    //    }

    //    public async Task<List<StudentAdminViewDto>> GetApprovedStudents()
    //    {
    //        var students = await _studentRepo.GetApprovedStudentsAsync();

    //        return students.Select(s => new StudentAdminViewDto
    //        {
    //            StudentId = s.Id,
    //            FullName = s.FullName,
    //            Email = s.Email,
    //            IsApproved = s.IsApproved
    //        }).ToList();
    //    }

    //    public async Task ApproveStudent(StudentApprovalDto dto)
    //    {
    //        var student = await _studentRepo.GetByIdAsync(dto.StudentId);
    //        if (student == null)
    //            throw new Exception("Student not found");

    //        student.IsApproved = dto.IsApproved;
    //        await _studentRepo.UpdateAsync(student);
    //    }

    //    public async Task AssignCoach(AssignCoachDto dto)
    //    {
    //        await _studentRepo.AssignCoachAsync(dto.StudentId, dto.CoachId);
    //    }
    //}
    public class AcademyService : IAcademyService
    {
        private readonly IAcademyRepository _academyRepo;

        public AcademyService(IAcademyRepository academyRepo)
        {
            _academyRepo = academyRepo;
        }

        public async Task<List<StudentAdminViewDto>> GetAllStudents()
        {
            var students = await _academyRepo.GetAllStudentsAsync();

            return students.Select(s => new StudentAdminViewDto
            {
                Id = s.Id,
                Name = s.FullName,
                IsApproved = s.IsApproved,
                CoachName = s.Coach != null ? s.Coach.FullName : null
            }).ToList();
        }

        public async Task<List<StudentAdminViewDto>> GetApprovedStudents()
        {
            var students = await _academyRepo.GetApprovedStudentsAsync();

            return students.Select(s => new StudentAdminViewDto
            {
                Id = s.Id,
                Name = s.FullName,
                IsApproved = s.IsApproved,
                CoachName = s.Coach != null ? s.Coach.FullName : null
            }).ToList();
        }

        public async Task ApproveStudent(StudentApprovalDto dto)
        {
            var student = await _academyRepo.GetStudentByIdAsync(dto.StudentId);

            if (student == null)
                throw new Exception("Student not found");

            student.IsApproved = dto.Approve;
            await _academyRepo.SaveAsync();
        }

        public async Task AssignCoach(AssignCoachDto dto)
        {
            var student = await _academyRepo.GetStudentByIdAsync(dto.StudentId);
            var coach = await _academyRepo.GetCoachByIdAsync(dto.CoachId);

            if (student == null)
                throw new Exception("Student not found");

            if (!student.IsApproved)
                throw new Exception("Student is not approved");

            if (coach == null)
                throw new Exception("Coach not found");

            student.CoachId = coach.Id;
            await _academyRepo.SaveAsync();
        }
    }
}

