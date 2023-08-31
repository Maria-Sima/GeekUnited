using System.Security.Claims;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        ITokenService tokenService)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.UserName
        };
    }


    public async Task<UserDto> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);


        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.UserName
        };
    }

    public async Task<UserDto> Register(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email
        };

         await _userManager.CreateAsync(user, registerDto.Password);


        return new UserDto
        {
            DisplayName = user.UserName,
            Token = _tokenService.CreateToken(user),
            Email = user.Email
        };
    }

    // public async Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
    // {
    //     var user = await _userManager.FindByEmailFromClaimsPrinciple(claimsPrincipal);
    //     return new UserDto
    //     {
    //         Email = user.Email,
    //         Token = _tokenService.CreateToken(user),
    //         DisplayName = user.UserName
    //     };
    // }
    public async Task<bool> CheckEmailExistsAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) != null;
    }
    
}