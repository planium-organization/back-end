using AutoMapper;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            #region Shared

            CreateMap<Course, DTOs.Shared.Course.CourseGetDto>();
            CreateMap<DTOs.Shared.Course.CoursePostDto, Course>();

            #endregion
        }
    }
}