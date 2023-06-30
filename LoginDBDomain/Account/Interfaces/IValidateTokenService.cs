namespace LoginDBServices.Account.Interfaces
{
    public interface IValidateTokenService
    {
        string ValidateToken(string token);
    }
}
