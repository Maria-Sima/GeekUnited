using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Utilities.Helpers;

namespace Infrastructure.Services;

public class PostService : IPostService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Post> _postsRepo;

    public PostService(
        IGenericRepository<Post> postsRepo,
        IMapper mapper
    )
    {
        _postsRepo = postsRepo;
        _mapper = mapper;
    }

    public async Task<Pagination<PostDto>> GetPosts(GeneralSpecParams generalSpecParams)
    {
        try
        {
            var spec = new PostWithBoardAndUserSpecifications(generalSpecParams);
            var countSpec = new PostWithFiltersForCountSpecification(generalSpecParams);
            var totalPosts = await _postsRepo.CountAsync(countSpec);
            IReadOnlyList<Post> posts = await _postsRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Post>, IReadOnlyList<PostDto>>(posts);

            return new Pagination<PostDto>(generalSpecParams.PageIndex, generalSpecParams.PageSize, totalPosts, data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Post> AddPost(PostRequestDto postForm)
    {
        throw new NotImplementedException();
    }


    public Task DeletePost(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetAllChildPost(string threadId)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePost(string id)
    {
        var postToDelete = await _postsRepo.GetByIdAsync(id);
        if (postToDelete != null)
            _postsRepo.Delete(id);
    }

    public Task AddCommentToPost(string threadId, string commentText, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetPostById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddCommentToPost(Post parentPost, Post commentPost)
    {
        throw new NotImplementedException();
    }

    public async Task<PostDto> GetPost(string id)
    {
        var spec = new PostWithBoardAndUserSpecifications(id);

        var post = await _postsRepo.GetEntityWithSpec(spec);

        return _mapper.Map<Post, PostDto>(post);
    }

    public async Task<Post> GetPostById(string id)
    {
        return await _postsRepo.GetByIdAsync(id);
    }

    public async Task AddCommentToPost(Post commentedPost) { }
}
