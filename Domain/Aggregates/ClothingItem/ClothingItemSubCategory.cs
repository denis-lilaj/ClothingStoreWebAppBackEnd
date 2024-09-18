using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ClothingItem
{
    public class ClothingItemSubCategory : BaseEntity
    {
        public string SubCategoryName { get; set; }
        public Guid? ParentSubCategoryId { get; set; }
        public ClothingItemSubCategory ParentSubCategory { get; set; }
        public ICollection<ClothingItemSubCategory> ChildSubCategories { get; set; }
        public Guid CategoryId { get; set; }
        public ClothingItemCategory Category { get; set; }
    }
}
