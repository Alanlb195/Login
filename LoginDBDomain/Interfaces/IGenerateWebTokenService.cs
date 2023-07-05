using LoginDB.Models;

namespace LoginDBServices.Interfaces
{
    public interface IGenerateWebTokenService
    {
        string GenerateWebToken(Account usuario, string roles);
    }
}
