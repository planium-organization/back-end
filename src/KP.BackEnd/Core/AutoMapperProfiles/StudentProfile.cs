using AutoMapper;
using KP.BackEnd.Core.DTOs.Supervisor.Student;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            #region Supervisor

            CreateMap<Student, StudentGetDto>();

            #endregion
        }
    }
}