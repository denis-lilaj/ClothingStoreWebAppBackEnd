using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.Queries
{
    public class GetUserIdQuery: IRequest<Guid>
    {
        public string Username { get; set; }

    }
}
