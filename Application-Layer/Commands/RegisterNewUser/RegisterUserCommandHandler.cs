using Domain_Layer.Models.UserModel;
using Infrastructure_Layer.Repositories.User;
using MediatR;
using Serilog;

namespace Application_Layer.Commands.RegisterNewUser
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;

        public  RegisterUserCommandHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.NewUser == null)
            {
                throw new ArgumentNullException("Invalid user data. FirstName,LastName,Email and Password are required.");
            }
            try
            {
                var userToCreate = new UserModel
                {
                    FirstName = request.NewUser.FirstName,
                    LastName = request.NewUser.LastName,
                    Email = request.NewUser.Email,
                    PasswordHash = request.NewUser.Password,
                    Role = "Admin"
                };

                var createdUser = await _userRepository.RegisterUser(userToCreate);

                return createdUser;
            }
            catch (Exception ex)
            {

                Log.Error("An error occurred while registering the user.", ex);
                throw;
            }

        }
    }
}
