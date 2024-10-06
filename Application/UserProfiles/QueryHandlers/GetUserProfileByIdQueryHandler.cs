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
    public class GetUserProfileByIdQueryHandler : IRequestHandler<Queries.GetUserProfileByIdQuery, UserProfile>
    {
        private readonly DbContextCustom _dbContext;

        public GetUserProfileByIdQueryHandler(DbContextCustom dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserProfile> Handle(Queries.GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.UserProfiles.FirstOrDefaultAsync(up=>up.Guid==request.UserProfileId);
        }
    }
}
 