using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Queries.GetUserByEmail
{
    //public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, IdentityUser>
    //{
    //private readonly IUserRepository _userRepository;

    //public GetUserByEmailQueryHandler(IUserRepository userRepository)
    //{
    //    _userRepository = userRepository;
    //}

    //public async Task<IdentityUser> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    //{
    //    if (string.IsNullOrWhiteSpace(request.Email))
    //    {
    //        throw new ArgumentException("Email cannot be empty!");
    //    }

    //    try
    //    {
    //        var user = await _userRepository.GetUserByEmailAsync(request.Email);
    //        if (user == null)
    //        {
    //            throw new KeyNotFoundException($"User with Email '{request.Email}' cannot be found!.");
    //        }

    //        return user;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}
}
