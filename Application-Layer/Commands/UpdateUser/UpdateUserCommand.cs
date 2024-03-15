using Application_Layer.DTO_s;
using Domain_Layer.Models.UserModel;
using MediatR;

namespace Application_Layer.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public UpdatingUserDTO UpdatingUserInfo { get; }
        public string Email { get; }
        public UpdateUserCommand(UpdatingUserDTO updateUser, string email) 
        {
            UpdatingUserInfo = updateUser;
            Email = email;
        }
    }
}
