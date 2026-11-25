using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(x => x.CreatedAt).HasColumnName("JoinDate").HasDefaultValueSql("GetDate()");
            builder.ToTable(
                t =>
                {
                    t.HasCheckConstraint("PlanDurationCheck", "DurationDays between 1 and 365");

                });
        }
    }
}
