using Domain.Aggregates.BusinessClothingItem;
using Domain.Aggregates.UserBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Business
{
    public class Business : BaseEntity
    {
        private readonly List<BusinessClothingItem.BusinessClothingItem> businessClothingItems=new List<BusinessClothingItem.BusinessClothingItem>();
        private readonly List<UserBusiness.UserBusiness> userBusinesses = new List<UserBusiness.UserBusiness>();

        private Business() {
        }
      
        public BusinessInfo BusinessInfo { get; private set; }
        public DateTime DateCreated { get; private set; }
        public IEnumerable<BusinessClothingItem.BusinessClothingItem> BusinessClothingItems { get { return businessClothingItems; } }
        public IEnumerable<UserBusiness.UserBusiness> UserBusinesses { get { return userBusinesses; } }

        public static Business CreateBusiness(BusinessInfo businessInfo) {

            var business = new Business
            {
                BusinessInfo=businessInfo,
                DateCreated = DateTime.UtcNow

            };

            return business;
            
        }

        private void AddBusinessClothingItem(BusinessClothingItem.BusinessClothingItem businessClothingItem)
        {
            businessClothingItems.Add(businessClothingItem);
        }

        private void AddUserBusiness(UserBusiness.UserBusiness userBusiness)
        {
            userBusinesses.Add(userBusiness);
        }

    }
}
