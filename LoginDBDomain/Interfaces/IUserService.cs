using LoginDBServices.Models.DTOs;

namespace LoginDBServices.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse?> Auth(AuthRequest model);
    }
}
