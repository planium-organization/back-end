using System;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(new Comment
                {
                    Id = Guid.Parse("dddd1111-1111-1111-1111-111111111111"),
                    Date = DateTime.Parse("2019-11-11"),
                    CreationTime = DateTime.Parse("2019-11-10T11:11:11"),
                    SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                    Text = "comment text 1",
                    StudentId = Guid.Parse("bbbb2222-1111-1111-1111-111111111111")
                }, new Comment
                {
                    Id = Guid.Parse("dddd1111-1111-1111-1111-111111111112"),
                    Date = DateTime.Parse("2019-11-11"),
                    CreationTime = DateTime.Parse("2019-11-12T11:11:11"),
                    SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                    Text = "comment text 2",
                    StudentId = Guid.Parse("bbbb2222-1111-1111-1111-111111111111")
                }
            );
        }
    }
}