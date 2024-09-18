using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Aggregates.ClothingItem;

namespace Infrastructure.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<ClothingItemCategory>
    {
        public void Configure(EntityTypeBuilder<ClothingItemCategory> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Guid);
            builder.Property(c => c.Guid)
                    .ValueGeneratedOnAdd();
          
        }
    }
}
