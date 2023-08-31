using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class PostService : IPostService
{
    private readonly IGenericRepository<Board> _boardRepo;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Post> _postsRepo;
    private readonly UserManager<AppUser> _userRepo;

    public PostService(IGenericRepository<Post> postsRepo, IMapper mapper, IFileService fileService,
        IGenericRepository<Board> boardRepo, UserManager<AppUser> userRepo)
    {
        _postsRepo = postsRepo;
        _mapper = mapper;
        _fileService = fileService;
        _boardRepo = boardRepo;
        _userRepo = userRepo;
    }

    public async Task<Pagination<PostDto>> GetPosts(PostSpecParams postSpecParams)
    {
        var spec = new PostWithBoardAndUserSpecifications(postSpecParams);
        var countSpec = new PostWithFiltersForCountSpecification(postSpecParams);
        var totalPosts = await _postsRepo.CountAsync(countSpec);
        var posts = await _postsRepo.ListAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Post>, IReadOnlyList<PostDto>>(posts);

        return new Pagination<PostDto>(postSpecParams.PageIndex, postSpecParams.PageSize, totalPosts, data);
    }

    public async Task<PostDto> GetPost(int id)
    {
        var spec = new PostWithBoardAndUserSpecifications(id);

        var post = await _postsRepo.GetEntityWithSpec(spec);

        return _mapper.Map<Post, PostDto>(post);
    }

    public async Task<PostDto> AddPost(PostForm postForm)
    {
        var blob = await _fileService.UploadAsync(postForm.Picture);
        var user = await _userRepo.FindByIdAsync(postForm.UserId.ToString());
        var board = await _boardRepo.GetByIdAsync(postForm.BoardId);
        var newPost = new Post
        {
            AppUser = user,
            UserId = postForm.UserId,
            PictureUrl = blob.Blob.Uri,
            Board = board,
            BoardId = postForm.BoardId,
            Description = postForm.Description,
            Title = postForm.Title
        };
        _postsRepo.Add(newPost);
        _postsRepo.SaveChangesAsync();
        return _mapper.Map<Post, PostDto>(newPost);
    }

    public async Task DeletePost(int id)
    {
        var postToDelete = await _postsRepo.GetByIdAsync(id);
        if (postToDelete != null)
        {
            _postsRepo.Delete(postToDelete);
            _postsRepo.SaveChangesAsync();
        }
    }
}