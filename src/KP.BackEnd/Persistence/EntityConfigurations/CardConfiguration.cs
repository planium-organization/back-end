using System;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData(new Card
                {
                    CourseId = Guid.Parse("eeee1111-1111-1111-1111-111111111112"),
                    Description = "supervisor 1",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111111"),
                    DueDate = DateTime.Parse("2018-11-11"),
                    Duration   =  new TimeSpan(1,11,11),
                    StartTime = null,
                    Status = CardStatus.Todo,
                    StudentId = Guid.Parse("bbbb2222-1111-1111-1111-111111111111"),
                    SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
                }, new Card
                {
                    CourseId = Guid.Parse("eeee1111-1111-1111-1111-111111111111"),
                    Description = "supervisor 2",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111112"),
                    DueDate = DateTime.Parse("2019-11-12"),
                    Duration   =  new TimeSpan(2,11,11),
                    StartTime = null,
                    Status = CardStatus.Done,
                    StudentId = Guid.Parse("bbbb2222-1111-1111-1111-111111111111"),
                    SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
                }, new Card
                {
                    CourseId = Guid.Parse("eeee1111-1111-1111-1111-111111111112"),
                    Description = "student 1",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111113"),
                    DueDate = DateTime.Parse("2018-11-13"),
                    Duration   =  new TimeSpan(1,11,11),
                    StartTime = null,
                    Status = CardStatus.Todo,
                    StudentId = Guid.Parse("bbbb2222-1111-1111-1111-111111111111")
                }, new Card
                {
                    CourseId = Guid.Parse("eeee1111-1111-1111-1111-111111111111"),
                    Description = "student 2",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111114"),
                    DueDate = DateTime.Parse("2019-11-14"),
                    Duration   =  new TimeSpan(1,11,11),
                    StartTime = null,
                    Status = CardStatus.Todo,
                    StudentId = Guid.Parse("bbbb2222-1111-1111-1111-111111111111")
                }
            );
        }
    }
}