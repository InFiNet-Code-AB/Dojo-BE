using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _manager;

        public GetUserByEmailQueryHandler(UserManager<IdentityUser> manager)
        {
            _manager = manager;
        }

        public async Task<IdentityUser> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new ArgumentException("E-postadressen får inte vara tom.");
            }

            var user = await _manager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new KeyNotFoundException($"Användaren med e-postadressen '{request.Email}' hittades inte.");
            }

            return user;
        }
    }
}
