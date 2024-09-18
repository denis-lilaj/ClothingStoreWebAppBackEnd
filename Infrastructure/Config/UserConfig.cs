using Domain.Aggregates.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class UserConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfile");
            builder.HasKey(x=>x.Guid);
            builder.OwnsOne(x=>x.BasicInfo);
            builder.Property(x => x.Guid).ValueGeneratedOnAdd();            
        }
    }
}
