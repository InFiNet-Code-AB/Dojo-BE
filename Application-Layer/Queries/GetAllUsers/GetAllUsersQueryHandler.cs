using Domain_Layer.Models.UserModel;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Queries.GetAllUsers
{
    //public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
    //{
    //    private readonly IUserRepository _userRepository;

    //    public GetAllUsersQueryHandler(IUserRepository userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }

    //    public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            return await _userRepository.Users.ToListAsync(cancellationToken);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new InvalidOperationException("Fail to pull all users!", ex);
    //        }
    //    }
    //}
}
