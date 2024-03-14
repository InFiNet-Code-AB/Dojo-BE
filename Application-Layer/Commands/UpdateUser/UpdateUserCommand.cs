using Application_Layer.DTO_s;
using Domain_Layer.Models.UserModel;
using MediatR;

namespace Application_Layer.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public UpdatingUserDTO UpdatedUser { get; }
        public Guid Id { get; }
        public UpdateUserCommand(UpdatingUserDTO updateUser, Guid id) 
        {
           UpdatedUser = updateUser;
           Id = id;
        }
    }
}
