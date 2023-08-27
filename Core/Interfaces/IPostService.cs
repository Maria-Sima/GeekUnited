using API.Dtos;
using Core.Specifications;
using Infrastructure.Helpers;

namespace Core.Interfaces;

public interface IPostService
{
    public Task<Pagination<PostDto>> GetPosts(PostSpecParams postSpecParams);
    public Task<PostDto> GetPost(int id);
}