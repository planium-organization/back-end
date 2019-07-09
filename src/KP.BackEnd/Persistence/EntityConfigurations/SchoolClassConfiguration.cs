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
            builder.HasIndex(sc => sc.Token);
            
            builder.HasData(new SchoolClass
            {
                Id = Guid.Parse("cccccccc-1111-1111-1111-111111111111"),
                SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                Name = "101",
                SchoolName = "Helli1",
                Token = "123456"
            },new SchoolClass
            {
                Id = Guid.Parse("cccccccc-1111-1111-1111-111111111112"),
                SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                Name = "202",
                SchoolName = "Helli2",
                Token = "134567"
            });
        }
    }
}