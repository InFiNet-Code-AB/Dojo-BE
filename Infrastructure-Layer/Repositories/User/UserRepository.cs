
using Domain_Layer.Models.UserModel;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure_Layer.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public Task<UserModel> RegisterUser(UserModel newUser)
        {
            throw new NotImplementedException();
        }

        Task<UserModel> IUserRepository.GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
