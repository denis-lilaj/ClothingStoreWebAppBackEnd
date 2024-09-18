using Domain.Aggregates.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Config
{
    public class BusinessConfig : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.ToTable("Businesses");
            builder.HasKey(x => x.Guid);
            builder.Property(x=>x.Guid).ValueGeneratedOnAdd();
            builder.OwnsOne(x=>x.BusinessInfo);

        }
    }
}
