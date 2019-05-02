using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP.BackEnd.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public ApplicationUser Identity { get; set; }
//        public Guid IdentityId { get; set; }
        public string Major { get; set; }
        public string SchoolName { get; set; }
//        public SchClass SchClass { get; set; }
    }
}