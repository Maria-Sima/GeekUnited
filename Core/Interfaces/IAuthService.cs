namespace Core.Interfaces;

public interface IAuthService
{
    public Task<string?> SignUp(string email, string password);
    public Task<string?> Login(string email, string password);
    public void SignOut();
}
