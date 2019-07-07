using System;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class SupervisorConfiguration : IEntityTypeConfiguration<Supervisor>
    {
        public void Configure(EntityTypeBuilder<Supervisor> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Identity)
                .WithOne()
                .HasForeignKey<Supervisor>(s => s.Id)
                .IsRequired();

            builder.HasData(new Supervisor
            {
                Id = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
            });
        }
    }
}