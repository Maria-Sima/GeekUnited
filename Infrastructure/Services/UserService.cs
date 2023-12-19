using API.Dtos;
using AutoMapper;
using Core.Documents;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly string _bucketName;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<UserDocument> _userRepo;


    public UserService(
        IGenericRepository<UserDocument> userRepo,
        IMapper mapper,
        IFileService fileService
    )
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _fileService = fileService;
        _bucketName = "users";
    }

    public void CreateNewUser(string userId, string email)
    {
        var newUser = new AppUser
        {
            Id = userId,
            Email = email
        };
        Console.WriteLine(newUser.Id);
        var userDocument = _mapper.Map<UserDocument>(newUser);
        Console.WriteLine(userDocument.Id);
        _userRepo.Add(userDocument);
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

        return _mapper.Map<AppUser>(user);
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

    public async Task<AppUser> OnboardUser(NewUserRequest userRequest)
    {
        try
        {
            var registeredUser = await GetUserById(userRequest.UserID) ?? throw new Exception("User not found");
            var photoUri = await _fileService.UploadFile(userRequest.Username, userRequest.ProfilePhoto, _bucketName);
            registeredUser.Name = userRequest.Name;
            registeredUser.Bio = userRequest.Bio;
            registeredUser.Username = userRequest.Username;
            registeredUser.ProfilePhoto = photoUri;
            registeredUser.Onboarded = true;
            var userDocument = _mapper.Map<UserDocument>(registeredUser);
            await _userRepo.UpdateAsync(userDocument);
            return registeredUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
