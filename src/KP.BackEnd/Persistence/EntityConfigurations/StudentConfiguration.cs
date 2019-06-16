using System;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            
            builder.HasOne(s => s.Identity)
                .WithOne()
                .HasForeignKey<Student>(s => s.Id)
                .IsRequired();
            
            builder.HasData(new Student
            {
                Id = Guid.Parse("bbbb2222-1111-1111-1111-111111111111")
            });
        }
    }
}