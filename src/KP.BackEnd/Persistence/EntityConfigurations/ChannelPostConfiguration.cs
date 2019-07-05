using System;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class ChannelPostConfiguration : IEntityTypeConfiguration<ChannelPost>
    {
        public void Configure(EntityTypeBuilder<ChannelPost> builder)
        {
            builder.HasData(new ChannelPost
                {
                    Id = Guid.Parse("aaaa1111-1111-1111-1111-111111111111"),
                    CreationTime = DateTime.Parse("2018-11-11T11:11:11"),
                    CreatorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                    Text = "example text 1",
                    Image = null
                }, new ChannelPost
                {
                    Id = Guid.Parse("aaaa1111-1111-1111-1111-111111111112"),
                    CreationTime = DateTime.Parse("2018-11-11T11:11:12"),
                    CreatorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                    Text = "example text 2",
                    Image = null
                }, new ChannelPost
                {
                    Id = Guid.Parse("aaaa1111-1111-1111-1111-111111111113"),
                    CreationTime = DateTime.Parse("2018-11-10T11:11:12"),
                    CreatorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                    Text = "example text 3",
                    Image = null
                }
            );
        }
    }
}