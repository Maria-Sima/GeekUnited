using System.Security.Claims;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<AppUser> _userRepo;


    public UserService(
        IGenericRepository<AppUser> userRepo,
        IMapper mapper
    )
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public AppUser CreateUser(NewUserRequest userRequest)
    {
        try
        {
            AppUser newUser = new AppUser
            {
                Name = userRequest.Name,
                Bio = userRequest.Bio,
                Username = userRequest.Username,
                ProfilePhoto = userRequest.ProfilePhoto
            };
             _userRepo.Add(newUser);
             return newUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    public Task<List<Post>> GetActivity(string userId)
    {
        throw new NotImplementedException();
    }





    public Task<CommentDto> AddComment(CommentRequestDto comm)
    {
        throw new NotImplementedException();
    }

    public async void AddPostToUser(string userId, string postId)
    {
        try
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");
            user.Posts.Add(postId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task AddBoardToMember(string userId, string boardId)
    {
        var user = await _userRepo.GetByIdAsync(userId);
        user.Boards.Add(boardId);
        await _userRepo.UpdateAsync(user);
    }

    public async Task<AppUser> GetUserById(string id)
    {
        var user = await _userRepo.GetByIdAsync(id);

        return user;
    }

    public Task<List<Post>> GerUserPosts(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AppUser>> GetUsers()
    {
        throw new NotImplementedException();
    }


    public async Task RemoveBoardFromUser(string boardId, string userId)
    {
        var user = await _userRepo.GetByIdAsync(userId);
        user.Boards.Remove(boardId);
        await _userRepo.UpdateAsync(user);
    }


}
