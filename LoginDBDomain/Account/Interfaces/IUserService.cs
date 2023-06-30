using LoginDBServices.Account.DTOs;

namespace LoginDBServices.Account.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse?> Auth(AuthRequest model);
    }
}
