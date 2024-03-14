using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public GetUserByIdQueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UserId))
            {
                throw new ArgumentException("UserId får inte vara tomt.");
            }

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.UserId} was not found!");
            }

            return user;
        }
    }
}
