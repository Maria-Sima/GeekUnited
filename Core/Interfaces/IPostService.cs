using API.Dtos;
using Core.Entities;
using Core.Specifications;
using Infrastructure.Helpers;

namespace Core.Interfaces;

public interface IPostService
{
    public Task<Pagination<PostDto>> GetPosts(PostSpecParams postSpecParams);
    public Task<PostDto> GetPost(int id);
    public Task<Post> AddPost(PostRequestDto postForm, AppUser user, Board board);
    public Task DeletePost(int id);

    public Task<Post> GetPostById(int id);

    public Task AddCommentToPost(Post post, Comment comment);
}