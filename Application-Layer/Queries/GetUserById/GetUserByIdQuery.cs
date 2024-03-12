using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<IdentityUser>
    {
        public string UserId { get; private set; }
        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
