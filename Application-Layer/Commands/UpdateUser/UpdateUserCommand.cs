using Application_Layer.DTO_s;
using Domain_Layer.Models.UserModel;
using MediatR;

namespace Application_Layer.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        UpdatingUserDTO UpdatingUserInfo { get; }
        string Email { get; }
        public UpdateUserCommand(UpdatingUserDTO userToUpdate, string email) 
        {
            UpdatingUserInfo = userToUpdate;
            Email = email;
        }

    }
}
