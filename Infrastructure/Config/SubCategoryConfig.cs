using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Aggregates.ClothingItem;


namespace Infrastructure.Config
{
    public class SubCategoryConfig : IEntityTypeConfiguration<ClothingItemSubCategory>
    {
        public void Configure(EntityTypeBuilder<ClothingItemSubCategory> builder)
        {
            builder.ToTable("SubCategories");
            builder.HasKey(sc => sc.Guid);
            builder.Property(sc => sc.Guid)
                   .ValueGeneratedOnAdd();
           
            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(sc => sc.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict); 
           
            builder.HasOne(sc => sc.ParentSubCategory)
                   .WithMany(sc => sc.ChildSubCategories)
                   .HasForeignKey(sc => sc.ParentSubCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}

