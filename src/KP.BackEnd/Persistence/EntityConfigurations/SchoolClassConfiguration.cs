using System;
using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class SchoolClassConfiguration: IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.HasData(new SchoolClass
            {
                Id = Guid.Parse("cccccccc-1111-1111-1111-111111111111"),
                SupervisorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                Name = "Mathematics",
                SchoolName = "SchoolName1"
            });
        }
    }
}