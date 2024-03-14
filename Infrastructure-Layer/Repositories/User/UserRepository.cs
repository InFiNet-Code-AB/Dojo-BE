using Domain_Layer.Models.UserModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public Task DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> RegisterUserAsync(UserModel newUser)
        {
            throw new NotImplementedException();
        }
    }
}
