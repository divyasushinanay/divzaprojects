using AutoMapper;
using Domain.Models;
using Domain.Services.Auth.Dto;
using Domain.Services.Coaches.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
   public class MappingProfile:Profile
    {
        public MappingProfile() {
            // Coach Mappings
            CreateMap<Coach, CoachRegisterDto>().ReverseMap();
            CreateMap<CoachResponseDto, Coach>().ReverseMap();
           CreateMap<VerifyOtpDto, Coach>().ReverseMap();




        }
    }
}
