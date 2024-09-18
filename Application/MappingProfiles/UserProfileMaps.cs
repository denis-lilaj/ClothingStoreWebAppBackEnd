using Application.UserProfiles.Commands;
using AutoMapper;
using Domain.Aggregates.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserProfileCommand, BasicInfo>();
        }

         
    }
}
