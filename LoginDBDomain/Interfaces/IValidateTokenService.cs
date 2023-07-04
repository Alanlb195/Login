namespace LoginDBServices.Interfaces
{
    public interface IValidateTokenService
    {
        public (string userName, string[] roles) ValidateToken(string token);
    }
}
