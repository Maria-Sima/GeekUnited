using System.Security.Claims;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IBoardService _boardService;
    private readonly IMapper _mapper;
    private readonly IPostService _postService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public UserService(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ITokenService tokenService,
        IPostService postService,
        IBoardService boardService,
        IMapper mapper
    )
    {
        _tokenService = tokenService;
        _postService = postService;
        _boardService = boardService;
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public Task<List<Post>> GetActivity(string userId)
    {
        throw new NotImplementedException();
    }


    public async Task<UserDto> Register(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            Name = registerDto.DisplayName,
            UserName = registerDto.DisplayName,
            Email = registerDto.Email
        };
        Console.WriteLine("!!" + user);
        await _userManager.CreateAsync(user, registerDto.Password);

        return new UserDto
        {
            DisplayName = user.UserName,
            Token = _tokenService.CreateToken(user),
            Email = user.Email
        };
    }

    public async Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);
        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.UserName
        };
    }

    public async Task<bool> CheckEmailExistsAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) != null;
    }


    public Task<CommentDto> AddComment(CommentRequestDto comm)
    {
        throw new NotImplementedException();
    }


    public async Task AddBoardToMember(string userId, string boardId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        user.Boards.Add(boardId);
        await _userManager.UpdateAsync(user);
    }

    public async Task<AppUser> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        return user;
    }

    public Task<List<Post>> GerUserPosts(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AppUser>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public async Task AddBoardCreatedByUser(string boardCreatedByUserId, AppUser user)
    {
        user.Boards.Add(boardCreatedByUserId);
        await _userManager.UpdateAsync(user);
    }

    public async Task RemoveBoardFromUser(string boardId, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        user.Boards.Remove(boardId);
        await _userManager.UpdateAsync(user);
    }

    public async Task<AppUser> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
            throw new Exception("Invalid email");
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        return user;
    }
}
