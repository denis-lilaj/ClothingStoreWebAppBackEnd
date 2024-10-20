using Application.Models;
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
    public class UpdateUserProfileBasicInfoCommandHandler : IRequestHandler<UpdateUserProfileBasicInfoCommand, OperationResult<UserProfile>>
    {
        private readonly DbContextCustom _dbContext;
        private readonly IMediator _mediator;

        public UpdateUserProfileBasicInfoCommandHandler(DbContextCustom dbContext, IMediator mediator)
        { 
           _dbContext = dbContext;
            _mediator = mediator;
        }
        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInfoCommand request, CancellationToken cancellationToken)
        {
            var result=new OperationResult<UserProfile>();

            try {
                var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x => x.Guid == request.UserProfileId);
                if(userProfile is null)
                {
                    result.isError = true;
                    var error = new Error { Code = ErrorCodes.NotFound, Message = $"No user profile with this ID was found {request.UserProfileId}" };
                    result.Errors.Add(error);
                    return result; 
                }
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.UserName, request.DateOfBirth,
                                                         request.Email, request.PhoneNumber);
                userProfile.UpdateBasicInfo(basicInfo);
                _dbContext.UserProfiles.Update(userProfile);
                await _dbContext.SaveChangesAsync();

                result.PayLoad = userProfile;
                return result;
            }
            catch(Exception ex) {
                result.isError=true;
                var error=new Error { Code=ErrorCodes.ServerError, Message=ex.Message };
                result.Errors.Add(error);
            }
 
            return result;
        }
    }
}
