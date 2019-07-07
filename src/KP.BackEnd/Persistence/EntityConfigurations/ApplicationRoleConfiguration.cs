using System;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(new ApplicationRole
                {
                    Id = Guid.Parse("bbbbbbbb-1111-1111-1111-111111111111"),
                    Name = "Student",
                    Description = "This is student role description",
                    NormalizedName = "STUDENT"
                }, new ApplicationRole
                {
                    Id = Guid.Parse("bbbbbbbb-1111-1111-1111-111111111112"),
                    Name = "Supervisor",
                    Description = "This is supervisor role description",
                    NormalizedName = "SUPERVISOR"
                }
            );
        }
    }
}