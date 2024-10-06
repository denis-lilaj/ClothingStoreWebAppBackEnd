using Application.UserProfiles.Commands;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.CommandHandlers
{
    public class DeleteUserProfileCommandHandler: IRequestHandler<DeleteUserProfileCommand>
    {
        private readonly DbContextCustom _dbContext;

        public DeleteUserProfileCommandHandler(DbContextCustom dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile=await _dbContext.UserProfiles.FirstOrDefaultAsync(x=>x.Guid==request.UserProfileId);

            _dbContext.UserProfiles.Remove(userProfile);
            await _dbContext.SaveChangesAsync();

            return new Unit();
        }
    }
}
