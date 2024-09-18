using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.UserProfile;

namespace Application.UserProfiles.Commands
{
    public class CreateUserProfileCommand : IRequest<UserProfile>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string PhoneNumber { get; set; }
    }
}
