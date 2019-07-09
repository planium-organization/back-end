using System;
using System.Collections.Generic;

namespace KP.BackEnd.Core.Models
{
    public class Student
    {
        private Guid _id;
        private ApplicationUser _identity;
        private string _major;
        private ICollection<Course> _courses;
        private SchoolClass _schoolClass;
        private ICollection<Card> _cards;

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

        public virtual SchoolClass SchoolClass
        {
            get => _schoolClass;
            set => _schoolClass = value;
        }

        public virtual ICollection<Course> Courses
        {
            get => _courses;
            set => _courses = value;
        }

        public virtual ICollection<Card> Cards
        {
            get => _cards;
            set => _cards = value;
        }

//        public Guid IdentityId { get; set; }
    }
}