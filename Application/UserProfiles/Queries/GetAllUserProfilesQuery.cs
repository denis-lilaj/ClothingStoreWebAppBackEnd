using Domain.Aggregates.UserProfile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.Queries
{
    public class GetAllUserProfilesQuery: IRequest<IEnumerable<UserProfile>>
    {

    }
}
