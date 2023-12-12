using API.Dtos;
using Core.Entities;

namespace Core.Interfaces;

public interface IUserService
{
    public Task<AppUser> GetUserById(string id);
    public Task<List<Post>> GerUserPosts(string userId);
    public Task<List<AppUser>> GetUsers();
    public Task<List<Post>> GetActivity(string userId);


    public Task<CommentDto> AddComment(CommentRequestDto comm);
    public void AddPostToUser(string userId, string postId);
    public Task AddBoardToMember(string userId, string boardId);


    public Task RemoveBoardFromUser(string boardId, string userId);
}
