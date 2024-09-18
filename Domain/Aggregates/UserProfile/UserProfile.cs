using Domain.Aggregates.UserBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.UserProfile
{
    public class UserProfile : BaseEntity
    {
        private UserProfile()
        {        
        }
        public string IdentityId { get; private set; }
        public BasicInfo BasicInfo { get; private set; }
        public DateTime DateCreated { get; private set; }   
        public DateTime LastModified { get; private set; }
        public ICollection<UserBusiness.UserBusiness> UserBusinesses { get; private set; }

        public static UserProfile CreateUserProfile(string identityId , BasicInfo basicInfo) {

            var userProfile = new UserProfile
            {
                IdentityId= identityId ,
                BasicInfo= basicInfo,
                DateCreated=DateTime.UtcNow,
                LastModified=DateTime.UtcNow
            };

            return userProfile;
        }

    }
}
