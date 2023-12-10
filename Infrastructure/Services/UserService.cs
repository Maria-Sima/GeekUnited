using System.Security.Claims;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<AppUser> _userRepo;


    public UserService(
        IGenericRepository<AppUser> userRepo,
        IMapper mapper
    )
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public Task<List<Post>> GetActivity(string userId)
    {
        throw new NotImplementedException();
    }


    // public async Task<UserDto> Register(RegisterDto registerDto)
    // {
    //     var user = new AppUser
    //     {
    //         Name = registerDto.DisplayName,
    //          = registerDto.DisplayName,
    //         Email = registerDto.Email
    //     };
    //     Console.WriteLine("!!" + user);
    //     await _userRepo.CreateAsync(user, registerDto.Password);
    //
    //     return new UserDto
    //     {
    //         DisplayName = user.UserName,
    //         Token = _tokenService.CreateToken(user),
    //         Email = user.Email
    //     };
    // }

    // public async Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
    // {
    //     var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
    //     var user = await _userRepo.FindByIdAsync(userId);
    //     return new UserDto
    //     {
    //         Email = user.Email,
    //         Token = _tokenService.CreateToken(user),
    //         DisplayName = user.UserName
    //     };
    // }

    // public async Task<bool> CheckEmailExistsAsync(string email)
    // {
    //     return await _userRepo.FindByEmailAsync(email) != null;
    // }


    public Task<CommentDto> AddComment(CommentRequestDto comm)
    {
        throw new NotImplementedException();
    }

    public async void AddPostToUser(string userId, string postId)
    {
        try
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");
            user.Posts.Add(postId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task AddBoardToMember(string userId, string boardId)
    {
        var user = await _userRepo.GetByIdAsync(userId);
        user.Boards.Add(boardId);
        await _userRepo.UpdateAsync(user);
    }

    public async Task<AppUser> GetUserById(string id)
    {
        var user = await _userRepo.GetByIdAsync(id);

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


    public async Task RemoveBoardFromUser(string boardId, string userId)
    {
        var user = await _userRepo.GetByIdAsync(userId);
        user.Boards.Remove(boardId);
        await _userRepo.UpdateAsync(user);
    }

    // public async Task<AppUser> Login(LoginDto loginDto)
    // {
    //     var user = await _userRepo.FindByEmailAsync(loginDto.Email);
    //     if (user == null)
    //         throw new Exception("Invalid email");
    //     var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
    //
    //     return user;
    // }
}
