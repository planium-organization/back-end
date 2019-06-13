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
                    Description = "example desc",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111111"),
                    DueDate = DateTime.Parse("2018-11-11"),
                    Duration   =  new TimeSpan(1,11,11),
                    StartTime = null,
                    Status = CardStatus.Todo,
                    StudentId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
                }, new Card
                {
                    Description = "example desc 2",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111112"),
                    DueDate = DateTime.Parse("2018-11-12"),
                    Duration   =  new TimeSpan(2,11,11),
                    StartTime = null,
                    Status = CardStatus.Done,
                    StudentId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
                }
            );
        }
    }
}