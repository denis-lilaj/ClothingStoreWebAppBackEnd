using Application.UserProfiles.Commands;
using AutoMapper;
using ClothingStoreWebAPI.Contracts.Requests;
using ClothingStoreWebAPI.Contracts.Responses;
using Domain.Aggregates.UserProfile;

namespace ClothingStoreWebAPI.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings() {
            CreateMap<UserProfileCreate, CreateUserProfileCommand>(); 
            CreateMap<UserProfile,UserProfileResponse>();
            CreateMap<BasicInfo, BasicInformation>();
        }
    }
}
 