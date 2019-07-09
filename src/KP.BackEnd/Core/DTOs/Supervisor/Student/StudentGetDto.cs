using System;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.DTOs.Supervisor.Student
{
    public class StudentGetDto
    {
        private Guid _id;
        private string _major;
        private string _schoolName;
        private string _email;
//        private ApplicationUser _identity;
//        private Guid _schoolClassId;


        public Guid Id 
        {
            get => _id;
            set => _id = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Major 
        {
            get => _major;
            set => _major = value;
        }

        public string SchoolName 
        {
            get => _schoolName;
            set => _schoolName = value;
        }
        
//        public ApplicationUser Identity 
//        {
//            get => _identity;
//            set => _identity = value;
//        }

//        public Guid SchoolClassId
//        {
//            get => _schoolClassId;
//            set => _schoolClassId = value;
//        }

    }
}