using Firebase.Auth;

namespace Core.Interfaces;

public interface IAuthService
{
    public Task<string?> SignUp(string email, string password);
    public Task<string?> Login(string email, string password);
    public void SignOut();
    public Task<bool> CheckIfEmailExists(string email);
    public User GetCurrentUser();

    public Task ResetPassword(string email);
}
