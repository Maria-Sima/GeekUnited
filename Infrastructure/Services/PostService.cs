using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Helpers;

namespace Infrastructure.Services;

public class PostService:IPostService
{
    private readonly IGenericRepository<Post> _postsRepo;
    private readonly IMapper _mapper;

    public PostService(IGenericRepository<Post> postsRepo,IMapper mapper)
    {
        _postsRepo = postsRepo;
        _mapper = mapper;
    }

    public async Task<Pagination<PostDto>> GetPosts(PostSpecParams postSpecParams)
    {
        var spec = new PostWithBoardAndUserSpecifications(postSpecParams);
        var countSpec = new PostWithFiltersForCountSpecification(postSpecParams);
        var totalPosts = await _postsRepo.CountAsync(countSpec);
        var posts = await _postsRepo.ListAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Post>, IReadOnlyList<PostDto>>(posts);
        
        return new Pagination<PostDto>(postSpecParams.PageIndex,postSpecParams.PageSize,totalPosts,data);
    }
    
    public async Task<PostDto> GetPost(int id)
    {
        var spec = new PostWithBoardAndUserSpecifications(id);

        var product = await _postsRepo.GetEntityWithSpec(spec);

        return _mapper.Map<Post, PostDto>(product);
    }
}