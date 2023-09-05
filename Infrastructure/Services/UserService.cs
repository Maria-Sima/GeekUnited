using System.Security.Claims;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IBoardService _boardService;
    private readonly IGenericRepository<Comment> _commentRepo;
    private readonly IMapper _mapper;
    private readonly IPostService _postService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        ITokenService tokenService, IPostService postService, IGenericRepository<Comment> commentRepo,
        IBoardService boardService, IMapper mapper)
    {
        _tokenService = tokenService;
        _postService = postService;
        _commentRepo = commentRepo;
        _boardService = boardService;
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.UserName
        };
    }


    public async Task<UserDto> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) throw new Exception("Invalid email");
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);


        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.UserName
        };
    }

    public async Task<UserDto> Register(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email
        };

        await _userManager.CreateAsync(user, registerDto.Password);


        return new UserDto
        {
            DisplayName = user.UserName,
            Token = _tokenService.CreateToken(user),
            Email = user.Email
        };
    }

    public async Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);
        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.UserName
        };
    }

    public async Task<bool> CheckEmailExistsAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) != null;
    }

    public async Task<PostDto> AddPost(PostRequestDto postForm)
    {
        var user = await _userManager.FindByIdAsync(postForm.UserId);
        if (user == null) throw new Exception("User not found");

        var board = await _boardService.GetBoardById(postForm.BoardId);
        if (board == null) throw new Exception("Board not found");

        var post = await _postService.AddPost(postForm, user, board);

        await _boardService.AddPostToBoard(post, board);

        user.Posts.Add(post);
        await _userManager.UpdateAsync(user);

        return _mapper.Map<Post, PostDto>(post);
    }


    public async Task<CommentDto> AddComment(CommentRequestDto comm)
    {
        var user = await _userManager.FindByIdAsync(comm.UserId);
        var post = await _postService.GetPostById(comm.PostId);
        var newComment = new Comment
        {
            User = user,
            UserId = comm.UserId,
            PostId = comm.PostId,
            Post = post,
            CommentText = comm.Text
        };
        _commentRepo.Add(newComment);
        user.Comments.Add(newComment);
        await _postService.AddCommentToPost(post, newComment);
        return _mapper.Map<Comment, CommentDto>(newComment);
    }


    public async Task SubscribeToBoard(string userId, int boardId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var board = await _boardService.GetBoardById(boardId);
        user.Boards.Add(board);
        await _userManager.UpdateAsync(user);
        await _boardService.AddUsersToBoard(user, boardId);
    }
}