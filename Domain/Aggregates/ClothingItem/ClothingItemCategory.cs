using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ClothingItem
{
    public class ClothingItemCategory : BaseEntity
    {
        public string CategoryName { get; set; }     
        public ICollection<ClothingItemSubCategory> SubCategories { get; set; }
        public ICollection<ClothingItem> ClothingItems { get; set; }
    }
}
