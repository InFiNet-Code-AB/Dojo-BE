using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<IdentityUser>
    {
        public string Email { get; private set; }
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
