using API.Dtos;
using AutoMapper;
using Core.Documents;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Utilities.Helpers;

namespace Infrastructure.Services;

public class PostService : IPostService
{
    private readonly IBoardService _boardService;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<PostDocument> _postsRepo;
    private readonly IUserService _userService;

    public PostService(
        IGenericRepository<PostDocument> postsRepo,
        IMapper mapper,
        IBoardService boardService,
        IUserService userService
    )
    {
        _postsRepo = postsRepo;
        _mapper = mapper;
        _boardService = boardService;
        _userService = userService;
    }

    public async Task<Pagination<Post>> GetPosts(GeneralSpecParams generalSpecParams)
    {
        try
        {
            var spec = new PostWithBoardAndUserSpecifications(generalSpecParams);
            var countSpec = new PostWithFiltersForCountSpecification(generalSpecParams);
            var totalPosts = await _postsRepo.CountAsync(countSpec);
            var posts = await _postsRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Post>>(posts);

            return new Pagination<Post>(generalSpecParams.PageIndex, generalSpecParams.PageSize, totalPosts, data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Post> AddPost(PostRequestDto postForm)
    {
        try
        {
            var board = await _boardService.GetBoardById(postForm.BoardId);
            var newPost = new Post
            {
                Id = postForm.Id,
                Text = postForm.Text,
                Author = postForm.UserId,
                Board = postForm.BoardId
            };
            _postsRepo.Add(_mapper.Map<PostDocument>(newPost));
            _userService.AddPostToUser(postForm.UserId, postForm.Id);
            return newPost;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IEnumerable<Post>> GetAllChildPost(string postId)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePost(string id)
    {
        try
        {
            var postToDelete = await _postsRepo.GetByIdAsync(id);
            if (postToDelete != null)
                await _postsRepo.DeleteAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Post> AddCommentToPost(string postId, string commentText, string userId)
    {
        try
        {
            var originalPost = await _postsRepo.GetByIdAsync(postId);

            if (originalPost == null)
                throw new InvalidOperationException("Post not found");

            // Create the new comment thread
            var commentPost = new Post
            {
                Text = commentText,
                Author = userId,
                ParentId = postId
            };

            _postsRepo.Add(_mapper.Map<PostDocument>(commentPost));

            originalPost.Children.Add(commentPost.Id);

            await _postsRepo.UpdateAsync(originalPost);
            return commentPost;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Post> GetPostById(string id)
    {
        var spec = new PostWithBoardAndUserSpecifications(id);

        var post = await _postsRepo.GetEntityWithSpec(spec);

        return _mapper.Map<Post>(post);
    }
}
