using Domain.Aggregates.UserBusiness;
using Domain.Aggregates.UserProfile;

namespace ClothingStoreWebAPI.Contracts.Responses
{
    public record UserProfileResponse
    {
        public string IdentityId { get; set; }
        public BasicInformation BasicInfo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public ICollection<UserBusiness> UserBusinesses { get; set; }
    }
}
