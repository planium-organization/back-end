using System;
using System.Collections.Generic;

namespace KP.BackEnd.Core.Models
{
    public class Supervisor
    {
        private Guid _id;
        private ApplicationUser _identity;
        private ICollection<Course> _courses;

        public Guid Id 
        {
            get => _id;
            set => _id = value;
        }

        public virtual ApplicationUser Identity
        {
            get => _identity;
            set => _identity = value;
        }

        public virtual ICollection<Course> Courses
        {
            get => _courses;
            set => _courses = value;
        }

//        public Guid IdentityId { get; set; }
//        public ICollection<SchClass> SchClasses { get; set; }
    }
}