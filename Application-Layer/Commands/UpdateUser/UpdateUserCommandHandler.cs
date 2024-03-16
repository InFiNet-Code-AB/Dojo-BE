using AutoMapper;
using Domain_Layer.Models.UserModel;
using Infrastructure_Layer.Repositories.User;
using MediatR;
using Serilog;

namespace Application_Layer.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetUserByEmailAsync(request.UsersEmail);
            if (userToUpdate == null)
            {
                throw new ArgumentNullException($"User with E-mail {request.UsersEmail} does not exist in the system!");
            }
            try
            {
                 userToUpdate = _mapper.Map<UserModel>(request.UpdatingUserInfo);

                var updatedUser = await _userRepository.UpdateUserAsync(userToUpdate);

                return updatedUser;
            }
            catch (Exception ex)
            {

                Log.Error("An error occurred while updating user inforamtion.", ex);
                throw;
            }
        }
    }
}


