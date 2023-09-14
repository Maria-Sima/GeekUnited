using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Helpers;

namespace Infrastructure.Services;

public class PostService : IPostService
{
    private readonly IFileService _fileService;

    private readonly IMapper _mapper;
    private readonly IGenericRepository<Post> _postsRepo;

    public PostService(IGenericRepository<Post> postsRepo, IMapper mapper, IFileService fileService)
    {
        _postsRepo = postsRepo;
        _mapper = mapper;
        _fileService = fileService;
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

    public async Task<Post> AddPost(PostRequestDto postForm, AppUser user, Board board)
    {
        var blob = await _fileService.UploadAsync(postForm.Picture);
        var newPost = new Post
        {
            AppUser = user,
            AppUserId = postForm.UserId,
            PictureUrl = blob.Blob.Uri,
            Board = board,
            BoardId = postForm.BoardId,
            Description = postForm.Description,
            Title = postForm.Title
        };
        _postsRepo.Add(newPost);
        _postsRepo.SaveChangesAsync();
        return newPost;
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

    public async Task<Post> GetPostById(int id)
    {
        return await _postsRepo.GetByIdAsync(id);
    }

    public async Task AddCommentToPost(Post commentedPost, Comment comment)
    {
        commentedPost.Comments.Add(comment);
        _postsRepo.SaveChangesAsync();
    }
}