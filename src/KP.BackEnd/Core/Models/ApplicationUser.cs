using System;
using Microsoft.AspNetCore.Identity;

namespace KP.BackEnd.Core.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() {}
        public ApplicationUser(string userName) : base(userName) {}
    }
}