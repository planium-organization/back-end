using System;
using System.Collections.Generic;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class SchoolClassConfiguration: IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            //TODO
            builder.HasData(new SchoolClass
<<<<<<< HEAD
                {
                    Id = Guid.Parse("yyyy1111-1111-1111-1111-111111111111"),
                    Name = "ClassName1",
                    SchoolName = "SchoolName1",
                    ChannelPosts = new List<ChannelPost>()
                    {
                        new ChannelPost
                        {
                            Id = Guid.Parse("aaaa1111-1111-1111-1111-111111111114"),
                            CreationTime = DateTime.Parse("2018-11-10T11:11:12"),
                            Text = "example text 4",
                            Image = null
                        }
                    }
                }, new SchoolClass
                {
                    Id = Guid.Parse("yyyy1111-1111-1111-1111-111111111112"),
                    Name = "classname2",
                    SchoolName = "SchoolName2"
                }
            );
=======
            {
                Id = Guid.Parse("cccccccc-1111-1111-1111-111111111111"),
                SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                Name = "Mathematics",
                SchoolName = "SchoolName1"
            });
>>>>>>> dev
        }
    }
}