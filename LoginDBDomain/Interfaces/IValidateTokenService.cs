namespace LoginDBServices.Interfaces
{
    public interface IValidateTokenService
    {
        string ValidateToken(string token);
    }
}
