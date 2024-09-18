using Domain.Aggregates.UserBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Config
{
    public class UserBusinessConfig : IEntityTypeConfiguration<UserBusiness>
    {
        public void Configure(EntityTypeBuilder<UserBusiness> builder)
        {
            builder.ToTable("UserBusinesses");
            builder.HasKey(ub => new { ub.UserId, ub.BusinessId });
           
            builder.HasOne(ub => ub.User)
                  .WithMany(u => u.UserBusinesses)
                  .HasForeignKey(ub => ub.UserId)
                  .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(ub => ub.Business)
                   .WithMany(b => b.UserBusinesses)
                   .HasForeignKey(ub => ub.BusinessId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
