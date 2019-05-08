using System;
using Microsoft.AspNetCore.Identity;

namespace KP.BackEnd.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}