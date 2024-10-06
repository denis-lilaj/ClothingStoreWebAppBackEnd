using Application.UserProfiles.Queries;
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
    public class GetUserIdQueryHandler : IRequestHandler<GetUserIdQuery, Guid>
    {
        private readonly DbContextCustom _dbContext;

        public GetUserIdQueryHandler(DbContextCustom dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Guid> Handle(GetUserIdQuery request, CancellationToken cancellationToken)
        {
            var result= await _dbContext.UserProfiles.FirstOrDefaultAsync(x=>x.BasicInfo.UserName==request.Username);
            return result.Guid;

        }
    }
}
