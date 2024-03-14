using Domain_Layer.Models.UserModel;

namespace Infrastructure_Layer.Repositories.User
{
    public interface IUserRepository
    {
        Task<UserModel> RegisterUserAsync(UserModel newUser);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel> UpdateUserAsync(UserModel updateUser);
    }
}
