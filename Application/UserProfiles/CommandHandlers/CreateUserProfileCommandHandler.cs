using Domain.Aggregates.UserProfile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UserProfiles.Commands;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.UserProfiles.CommandHandlers
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
    {
        private readonly DbContextCustom _dbContext;

        public CreateUserProfileCommandHandler(DbContextCustom dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName,request.LastName,request.UserName,request.DateOfBirth,
                                                      request.Email, request.PhoneNumber);

            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(),basicInfo);

            _dbContext.UserProfiles.Add(userProfile);
            await _dbContext.SaveChangesAsync();

            return userProfile;
        }
    }
}
