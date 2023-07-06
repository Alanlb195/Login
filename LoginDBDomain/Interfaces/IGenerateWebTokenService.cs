using LoginDB.Models;

namespace LoginDBServices.Interfaces
{
    public interface IGenerateWebTokenService
    {
        string GenerateWebToken(Account usuario, Rol rol);
    }
}
