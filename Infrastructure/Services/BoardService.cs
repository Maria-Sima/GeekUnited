using AutoMapper;
using Core.Documents;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Utilities.Helpers;

namespace Infrastructure.Services;

public class BoardService : IBoardService
{
    private readonly string _boardBucket;
    private readonly IGenericRepository<BoardDocument> _boardRepo;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public BoardService(
        IGenericRepository<BoardDocument> boardRepo,
        IUserService userService,
        IFileService fileService,
        IMapper mapper
    )
    {
        _boardBucket = "boards";
        _boardRepo = boardRepo;
        _userService = userService;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<Board> AddMembersToBoard(string userId, string boardId)
    {
        try
        {
            var board = await _boardRepo.GetByIdAsync(boardId);


            var user = await _userService.GetUserById(userId);

            if (board.Members.Contains(user.Id))
                throw new Exception("User is already a member of this board");

            board.Members.Add(user.Id);

            await _boardRepo.UpdateAsync(board);

            return _mapper.Map<Board>(board);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Pagination<Board>> GetBoards(GeneralSpecParams specParams)
    {
        try
        {
            ISpecification<BoardDocument> spec = new BoardWithMembersSpecification(specParams);
            ISpecification<BoardDocument> countSpec = new BoardWithFiltersForCountSpecification();
            var totalBoards = await _boardRepo.CountAsync(countSpec);
            var documents = await _boardRepo.ListAsync(spec);
            IReadOnlyList<Board> boards = _mapper.Map<List<Board>>(documents);
            return new Pagination<Board>(specParams.PageIndex, specParams.PageSize, totalBoards, boards);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Board> GetBoardById(string boardId)
    {
        try
        {
            var boardDocument = await _boardRepo.GetByIdAsync(boardId);
            return _mapper.Map<Board>(boardDocument);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task GetBoardPosts(string id)
    {
        // Implement the logic for fetching board posts
    }

    public async Task<Board> GetBoardDetails(string boardId)
    {
        try
        {
            var boardDetails = await _boardRepo.GetByIdAsync(boardId);
            return _mapper.Map<Board>(boardDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task RemoveUsersFromBoard(string boardId, string userId)
    {
        try
        {
            var user = await _userService.GetUserById(userId);
            var board = await _boardRepo.GetByIdAsync(boardId);

            if (user == null)
                throw new Exception("User not found");

            if (board == null)
                throw new Exception("Board not found");

            board.Members.Remove(userId);

            await _boardRepo.UpdateAsync(board);

            await _userService.RemoveBoardFromUser(boardId, userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteBoard(string boardId)
    {
        try
        {
            var board = await _boardRepo.GetByIdAsync(boardId);
            if (board == null)
                throw new Exception("Board not found");
            await _boardRepo.DeleteAsync(boardId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddPostToBoard(Board board, string postId)
    {
        try
        {
            board.Posts.Add(postId);
            _boardRepo.UpdateAsync(_mapper.Map<BoardDocument>(board));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task UpdateBoardInfo(string boardId, string name, string username, IFormFile image)
    {
        try
        {
            var board = await _boardRepo.GetByIdAsync(boardId);
            var imageUri = await _fileService.UploadFile(board.BoardName, image, _boardBucket);

            if (board == null)
                throw new Exception("Board not found");

            board.BoardName = name;
            board.Username = username;
            board.Image = imageUri;

            await _boardRepo.UpdateAsync(board);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Board> CreateBoard(
        string id,
        string name,
        string username,
        IFormFile image,
        string bio,
        string createdById
    )
    {
        try
        {
            var user = await _userService.GetUserById(createdById);

            if (user == null)
                throw new Exception("User Not Found");
            var photoUri = await _fileService.UploadFile(name, image, _boardBucket);
            var newBoard = new Board
            {
                Id = id,
                BoardName = name,
                Username = username,
                Image = photoUri,
                Bio = bio,
                CreatedBy = user.Id
            };

            _boardRepo.Add(_mapper.Map<BoardDocument>(newBoard));
            await _userService.AddBoardToMember(createdById, id);

            return newBoard;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error creating board:", ex);
            throw;
        }
    }
}
