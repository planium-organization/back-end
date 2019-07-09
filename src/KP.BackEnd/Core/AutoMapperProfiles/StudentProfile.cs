using AutoMapper;
using KP.BackEnd.Core.DTOs.Shared.Profile;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentGetDto>()
                .ForMember(dto => dto.UserName, m => m.MapFrom(src => src.Identity.UserName))
                .ForMember(dto => dto.Email, m => m.MapFrom(src => src.Identity.Email))
                .ForMember(dto => dto.FirstName, m => m.MapFrom(src => src.Identity.FirstName))
                .ForMember(dto => dto.LastName, m => m.MapFrom(src => src.Identity.LastName))
                .ForMember(dto => dto.Image, m => m.MapFrom(src => src.Identity.Image))
                .ForMember(dto => dto.SchoolName, m => m.MapFrom(src => src.SchoolClass.Name))
                .ForMember(dto => dto.SchoolClassName, m => m.MapFrom(src => src.SchoolClass.Name))
                .ForMember(dto => dto.Major, m => m.MapFrom(src => src.Major));

        }
    }
}