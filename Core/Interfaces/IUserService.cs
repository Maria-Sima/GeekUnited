using System.Security.Claims;
using API.Dtos;
using Core.Entities;

namespace Core.Interfaces;

public interface IUserService
{
    public Task<AppUser> GetUserById(string id);
    public Task<List<Post>> GerUserPosts(string userId);
    public Task<List<AppUser>> GetUsers();
    public Task<List<Post>> GetActivity(string userId);
    public Task<AppUser> Login(LoginDto loginDto);
    public Task<UserDto> Register(RegisterDto registerDto);
    public Task<bool> CheckEmailExistsAsync(string email);
    public Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal);
    public Task<PostDto> AddPost(PostRequestDto postForm);
    public Task<CommentDto> AddComment(CommentRequestDto comm);
    public Task SubscribeToBoard(string userId, string boardId);
    public Task AddBoardToMember(string userId, string boardId);
    public Task AddBoardCreatedByUser(string boardCreatedByUserId, AppUser user);

    public Task RemoveBoardFromUser(string boardId, string userId);
}
