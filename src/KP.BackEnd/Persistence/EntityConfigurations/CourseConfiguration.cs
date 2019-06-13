using System;
using AutoMapper;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class CourseConfiguration: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(new Course
                {
                    Color = "#f4ee42",
                    Id = Guid.Parse("eeee1111-1111-1111-1111-111111111111"),
                    Title = "Math"
                }, new Course
                {
                    Color = "#f44141",
                    Id = Guid.Parse("eeee1111-1111-1111-1111-111111111112"),
                    Title = "Theology"
                }
            );
        }
    }
}