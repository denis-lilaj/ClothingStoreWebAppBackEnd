using Domain.Aggregates.UserProfile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<UserProfile>
    {
        public Guid UserProfileId { get; set; } 
    }
}
