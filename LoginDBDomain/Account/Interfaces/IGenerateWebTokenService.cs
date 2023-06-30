using LoginDB.Models;

namespace LoginDBServices.Account.Interfaces
{
    public interface IGenerateWebTokenService
    {
        string GenerateWebToken(Account usuario, List<string> roles);
    }
}
