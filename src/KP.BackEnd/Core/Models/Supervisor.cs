using System;

namespace KP.BackEnd.Core.Models
{
    public class Supervisor
    {
        private Guid _id;
        private ApplicationUser _identity;

        public Guid Id {
            get => _id;
            set => _id = value;
        }

        public ApplicationUser Identity {
            get => _identity;
            set => _identity = value;
        }

//        public Guid IdentityId { get; set; }
//        public ICollection<SchClass> SchClasses { get; set; }
    }
}