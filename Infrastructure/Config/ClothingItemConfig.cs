using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Aggregates.ClothingItem;

namespace Infrastructure.Entities
{
    public class ClothingItemConfig : IEntityTypeConfiguration<ClothingItem>
    {
        public void Configure(EntityTypeBuilder<ClothingItem> builder)
        {
            builder.ToTable("ClothingItems");
            builder.HasKey(x=>x.Guid);
            builder.HasOne(ca => ca.ClothingItemCategory).
                    WithMany(ci => ci.ClothingItems).
                    HasForeignKey(ca => ca.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
