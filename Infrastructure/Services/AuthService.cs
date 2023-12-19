using Core.Entities;
using Core.Interfaces;
using Firebase.Auth;
using FirebaseAdmin.Auth;

namespace Infrastructure.Services;

public class AuthService : IAuthService

{
    private readonly FirebaseAuthClient _firebaseAuth;
    private readonly IUserService _userService;


    public AuthService(FirebaseAuthClient firebaseAuth, IUserService userService)
    {
        _firebaseAuth = firebaseAuth;
        _userService = userService;
    }

    public async Task<string?> SignUp(string email, string password)
    {
        try
        {
            var userCredentials = await _firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);

            _userService.CreateNewUser(userCredentials.User.Uid, email);

            return await userCredentials.User.GetIdTokenAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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


    public async Task<AppUser> GetCurrentUser(string token)
    {
        try
        {
            var decodedToken = FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
            var user = await _userService.GetUserById(decodedToken.Result.Uid);
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public User GetUser()
    {
        return _firebaseAuth.User;
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
