using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.BusinessClothingItem;

namespace Domain.Aggregates.ClothingItem
{
    public class ClothingItem : BaseEntity
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string TypeOfMaterial { get; set; }
        public string ShortDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid CategoryId { get; set; }
        public ClothingItemCategory ClothingItemCategory { get; set; }
        public IEnumerable<BusinessClothingItem.BusinessClothingItem> BusinessClothingItems { get;set; }
    }
}
