﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure_Layer.Repositories.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Queries.GetUserById
{
    //public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IdentityUser>
    //{
    //    private readonly IUserRepository _userRepository;

    //    public GetUserByIdQueryHandler(IUserRepository userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }

    //    public async Task<IdentityUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        if (string.IsNullOrWhiteSpace(request.UserId))
    //        {
    //            throw new ArgumentException("UserId cannot be empty.");
    //        }

    //        var user = await _userRepository.GetUserByIdAsync(request.UserId);
    //        if (user == null)
    //        {
    //            throw new KeyNotFoundException($"User with ID {request.UserId} was not found!");
    //        }

    //        return user;
    //    }
    //}
}
