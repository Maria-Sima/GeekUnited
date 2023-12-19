using Core.Entities;
using Firebase.Auth;

namespace Core.Interfaces;

public interface IAuthService
{
    public Task<string?> SignUp(string email, string password);
    public Task<string?> Login(string email, string password);
    public void SignOut();
    public Task<bool> CheckIfEmailExists(string email);
    public Task<AppUser> GetCurrentUser(string token);
    public User GetUser();

    public Task ResetPassword(string email);
}
