using System;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public static Guid SupervisorIdTmp = Guid.Parse("bbbb1111-1111-1111-1111-111111111111");
        public static Guid StudentIdTmp = Guid.Parse("bbbb2222-1111-1111-1111-111111111111");

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(new ApplicationUser
                {
                    Id = SupervisorIdTmp,
                    UserName = "supervisor@gmail.com",
                    NormalizedUserName = "SUPERVISOR@GMAIL.COM",
                    Email = "supervisor@gmail.com",
                    NormalizedEmail = "SUPERVISOR@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "supervisor123"),
                    SecurityStamp = string.Empty
                },
                new ApplicationUser
                {
                    Id = StudentIdTmp,
                    UserName = "student@gmail.com",
                    NormalizedUserName = "STUDENT@GMAIL.COM",
                    Email = "student@gmail.com",
                    NormalizedEmail = "STUDENT@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "student123"),
                    SecurityStamp = string.Empty
                }
            );
        }
    }
}