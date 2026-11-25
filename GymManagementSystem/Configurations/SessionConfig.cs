using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.CreatedAt).HasColumnName("JoinDate").HasDefaultValueSql("GetDate()");
            builder.HasOne(x=>x.Trainer).WithMany(s=>s.Sessions)
                .HasForeignKey(x=>x.TrainerId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable(
                t =>
                {
                    t.HasCheckConstraint("SessionCapacityConstraint", "Capacity between 1 and 25");
                    t.HasCheckConstraint("SessionEndDateAfterStartDateConstraint", "EndDate > StartDate");
                });
        }
    }
}
