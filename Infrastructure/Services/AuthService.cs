using Core.Interfaces;
using Firebase.Auth;

namespace Infrastructure.Services;

public class AuthService : IAuthService

{
    private readonly FirebaseAuthClient _firebaseAuth;


    public AuthService(FirebaseAuthClient firebaseAuth)
    {
        _firebaseAuth = firebaseAuth;
    }

    public async Task<string?> SignUp(string email, string password)
    {
        var userCredentials = await _firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
        return userCredentials is null ? null : await userCredentials.User.GetIdTokenAsync();
    }

    public async Task<string?> Login(string email, string password)
    {
        var userCredentials = await _firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
        return userCredentials is null ? null : await userCredentials.User.GetIdTokenAsync();
    }

    public void SignOut()
    {
        try
        {
            _firebaseAuth.SignOut();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public User GetCurrentUser()
    {
        try
        {
            return _firebaseAuth.User;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<bool> CheckIfEmailExists(string email)
    {
        try
        {
            var result = await _firebaseAuth.FetchSignInMethodsForEmailAsync(email);
            return result.UserExists;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task ResetPassword(string email)
    {
        try
        {
            await _firebaseAuth.ResetEmailPasswordAsync(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
