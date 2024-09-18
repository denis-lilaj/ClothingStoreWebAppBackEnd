using Domain.Aggregates.Business;
using Domain.Aggregates.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.UserBusiness
{
    public class UserBusiness
    {
        public Guid UserId { get; set; }
        public UserProfile.UserProfile User { get; set; }

        public Guid BusinessId { get; set; }
        public Business.Business Business { get; set; }
    }
}
