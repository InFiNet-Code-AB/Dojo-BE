
using Domain_Layer.Models.UserModel;

namespace Infrastructure_Layer.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public Task<UserModel> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> RegisterUserAsync(UserModel newUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> UpdateUserAsync(UserModel updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
