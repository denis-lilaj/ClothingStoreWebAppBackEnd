using Application.UserProfiles.Queries;
using Domain.Aggregates.UserProfile;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.QueryHandlers
{
    public class GetUserProfileByIdQuery : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DbContextCustom _dbContext;

        public GetUserProfileByIdQuery(DbContextCustom dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserProfile> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            return await _dbContext.UserProfiles.FirstOrDefaultAsync(up=>up.Guid==request.UserProfileId);
        }
    }
}
 