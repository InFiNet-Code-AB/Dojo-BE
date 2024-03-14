using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.UserModel;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Commands.DeleteUser
{
    //public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    //{
    //private readonly IUserRepository _userRepository;

    //public DeleteUserCommandHandler(IUserRepository userRepository)
    //{
    //    _userRepository = userRepository;
    //}

    //public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        var user = await _userRepository.GetUserByIdAsync(request.UserId);
    //        if (user == null)
    //        {
    //            throw new InvalidOperationException($"User with ID {request.UserId} was not found.");
    //        }

    //        var success = await _userRepository.DeleteUserByIdAsync(user);
    //        if (!success)
    //        {
    //            throw new InvalidOperationException("Failed to update the user.");
    //        }

    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}

    //}
}
