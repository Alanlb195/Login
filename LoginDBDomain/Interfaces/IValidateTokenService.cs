namespace LoginDBServices.Interfaces
{
    public interface IValidateTokenService
    {
        public string ValidateToken(string token);
    }
}
