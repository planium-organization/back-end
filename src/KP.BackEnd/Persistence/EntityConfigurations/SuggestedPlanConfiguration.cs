using KP.BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KP.BackEnd.Persistence.EntityConfigurations
{
    public class SuggestedPlanConfiguration : IEntityTypeConfiguration<SuggestedPlan>
    {
        public void Configure(EntityTypeBuilder<SuggestedPlan> builder)
        {
            builder.HasOne(sp => sp.SchoolClass)
                .WithOne(sc => sc.SuggestedPlan)
                .HasForeignKey<SuggestedPlan>(sp => sp.SuggestedPlanId);
        }
    }
}