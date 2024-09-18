using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Aggregates.BusinessClothingItem;


namespace Infrastructure.Config
{
    public class BusinessClothingItemConfig : IEntityTypeConfiguration<BusinessClothingItem>
    {
        public void Configure(EntityTypeBuilder<BusinessClothingItem> builder)
        {
            builder.ToTable("BusinessClothingItems");
            builder.HasKey(bci => new { bci.BusinessId, bci.ClothingItemId });
            builder.Property(bci => bci.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
            builder.Property(bci => bci.Quantity)
                   .IsRequired();

            builder.HasOne(bci => bci.Business)
                   .WithMany(b => b.BusinessClothingItems)
                   .HasForeignKey(bci => bci.BusinessId)
                   .OnDelete(DeleteBehavior.Cascade); 
           
            builder.HasOne(bci => bci.ClothingItem)
                   .WithMany(ci => ci.BusinessClothingItems)
                   .HasForeignKey(bci => bci.ClothingItemId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
