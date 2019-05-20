using System;

namespace KP.BackEnd.Models
{
    public class Supervisor
    {
        public Guid Id { get; set; }
        public ApplicationUser Identity { get; set; }

//        public Guid IdentityId { get; set; }
//        public ICollection<SchClass> SchClasses { get; set; }
    }
}