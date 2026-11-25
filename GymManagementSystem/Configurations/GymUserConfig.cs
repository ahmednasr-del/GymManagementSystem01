using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class GymUserConfig<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name).HasColumnType("varchar(50)");
            builder.Property(x => x.Phone).HasColumnType("varchar(11)");
            builder.ComplexProperty(x => x.Address);
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.Phone).IsUnique();
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("GymUser_EmailCheck", "Email like '_%@_%._%'");
                t.HasCheckConstraint("GymUser_PhoneCheck", "len(Phone) = 11 and (Phone like '010%' or Phone like '011%' or Phone like '012%' or Phone like '015%')");
            });
        }
    }
}
