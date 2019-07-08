using System;
using System.Collections.Generic;

namespace KP.BackEnd.Core.Models
{
    public class Student
    {
        private Guid _id;
        private ApplicationUser _identity;
        private string _major;
        private string _schoolName;
        private Guid _schoolClassId;
        private ICollection<Course> _courses;

        public Guid Id {
            get => _id;
            set => _id = value;
        }

        public virtual ApplicationUser Identity 
        {
            get => _identity;
            set => _identity = value;
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

        public Guid SchoolClassId
        {
            get => _schoolClassId;
            set => _schoolClassId = value;
        }

        public virtual ICollection<Course> Courses
        {
            get => _courses;
            set => _courses = value;
        }

//        public Guid IdentityId { get; set; }
    }
}