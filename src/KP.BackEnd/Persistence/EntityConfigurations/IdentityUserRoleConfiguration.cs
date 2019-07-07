using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("bbbbbbbb-1111-1111-1111-111111111111"),
                UserId = ApplicationUserConfiguration.StudentIdTmp
            }, new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("bbbbbbbb-1111-1111-1111-111111111112"),
                UserId = ApplicationUserConfiguration.SupervisorIdTmp
            });
        }
    }
}