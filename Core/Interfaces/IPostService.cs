using API.Dtos;
using Core.Entities;
using Core.Specifications;
using Utilities.Helpers;

namespace Core.Interfaces;

public interface IPostService
{
    public Task<Pagination<PostDto>> GetPosts(GeneralSpecParams generalSpecParams);
    public Task<PostDto> GetPost(string id);
    public Task<Post> AddPost(PostRequestDto postForm);
    public Task DeletePost(int id);
    public Task GetAllChildPost(string threadId);
    public Task DeletePost(string threadId);
    public Task AddCommentToPost(string threadId, string commentText, string userId);

    public Task<Post> GetPostById(int id);

    public Task AddCommentToPost(Post parentPost, Post commentPost);
}
