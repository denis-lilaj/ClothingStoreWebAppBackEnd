using Application.UserProfiles.Commands;
using Domain.Aggregates.UserProfile;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.CommandHandlers
{
    public class UpdateUserProfileBasicInfoCommandHandler : IRequestHandler<UpdateUserProfileBasicInfoCommand>
    {
        private readonly DbContextCustom _dbContext;
        private readonly IMediator _mediator;

        public UpdateUserProfileBasicInfoCommandHandler(DbContextCustom dbContext, IMediator mediator)
        { 
           _dbContext = dbContext;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(UpdateUserProfileBasicInfoCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x=>x.Guid==request.UserProfileId);
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.UserName, request.DateOfBirth,
                                                     request.Email, request.PhoneNumber);
            userProfile.BasicInfo.UpdateBasicInfo(basicInfo);
            _dbContext.UserProfiles.Update(userProfile);  
            await _dbContext.SaveChangesAsync();

            return new Unit();
        }
    }
}
