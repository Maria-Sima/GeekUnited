using API.Dtos;
using Core.Entities;
using Core.Specifications;
using Utilities.Helpers;

namespace Core.Interfaces;

public interface IPostService
{
    public Task<Pagination<Post>> GetPosts(GeneralSpecParams generalSpecParams);
    public Task<Post> GetPostById(string id);
    public Task<Post> AddPost(PostRequestDto postForm);

    public Task<IEnumerable<Post>> GetAllChildPost(string threadId);
    public Task DeletePost(string threadId);
    public Task<Post> AddCommentToPost(string threadId, string commentText, string userId);
}
