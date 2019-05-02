using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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