using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Services.Attendances.DTO;
using Domain.Services.Auth.Dto;
using Domain.Services.Coaches.DTO;
using Domain.Services.Studentz.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Coach Mappings
            CreateMap<Coach, CoachRegisterDto>().ReverseMap();
            CreateMap<CoachResponseDto, Coach>().ReverseMap();
            CreateMap<VerifyOtpRequestDto, Coach>().ReverseMap();
            CreateMap<MarkAttendanceDto, Attendance>();

            // Attendance entity → Response DTO
            CreateMap<Attendance, AttendanceResponseDto>();
            CreateMap<Student, StudentCreateDto>();

            // Domain → Entity
            CreateMap<StudentCreateDto, Student>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Parent, opt => opt.Ignore());

            CreateMap<Student, StudentResponseDto>();
        }
    }
}
