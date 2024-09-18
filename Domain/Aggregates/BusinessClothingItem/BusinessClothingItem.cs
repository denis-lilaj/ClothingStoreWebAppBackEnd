using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.BusinessClothingItem
{
    public class BusinessClothingItem
    {
        public Guid BusinessId { get; private set; }
        public Business.Business Business { get; private set; }

        public Guid ClothingItemId { get; private set; }
        public ClothingItem.ClothingItem ClothingItem { get; private set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
