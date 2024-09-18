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
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfile>>
    {
        private readonly DbContextCustom _dbContext;

        public GetAllUserProfilesQueryHandler(DbContextCustom dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.UserProfiles.ToListAsync();
        }
    }
}
