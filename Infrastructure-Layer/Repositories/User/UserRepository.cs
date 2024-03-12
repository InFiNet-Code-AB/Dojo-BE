
using Domain_Layer.Models.UserModel;

namespace Infrastructure_Layer.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        // When you are done with writing methods in IUserRepository you can Implement IUserRepository
        public Task<UserModel> RegisterUser(UserModel newUser)
        {
            throw new NotImplementedException();
        }
    }
}
