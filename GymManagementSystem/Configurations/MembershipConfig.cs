using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class MembershipConfig : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasColumnName("JoinDate").HasDefaultValueSql("GetDate()");
            builder.HasOne(x => x.Plan)
                .WithMany(p => p.Memberships).HasForeignKey(m => m.PlanId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
