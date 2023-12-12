using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Utilities.Helpers;

namespace Infrastructure.Services;

public class BoardService : IBoardService
{
    private readonly IGenericRepository<Board> _boardRepo;
    private readonly IUserService _userService;


    public BoardService(IGenericRepository<Board> boardRepo, IUserService userService)
    {
        _boardRepo = boardRepo;
        _userService = userService;
    }


    public async Task<Board> CreateBoard(
        string id,
        string name,
        string username,
        string image,
        string bio,
        string createdById
    )
    {
        try
        {
            var user = await _userService.GetUserById(createdById);

            if (user == null)
                throw new Exception("User Not Found");

            var newBoard = new Board
            {
                Id = id,
                BoardName = name,
                Username = username,
                Image = image,
                Bio = bio,
                CreatedBy = user.Id
            };

            _boardRepo.Add(newBoard);
            await _userService.AddBoardToMember(createdById, id);

            return newBoard;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error creating board:", ex);
            throw;
        }
    }

    public async Task<Board> AddMembersToBoard(string userId, string boardId)
    {
        try
        {
            var board = await _boardRepo.GetByIdAsync(boardId);
            if (board == null)
                throw new Exception("Board Not Found");

            var user = await _userService.GetUserById(userId);
            if (user == null)
                throw new Exception("User not found");

            if (board.Members.Contains(user.Id))
                throw new Exception("User is already a member of this board");

            board.Members.Add(user.Id);

            await _boardRepo.UpdateAsync(board);

            return board;
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
            var spec = new BoardWithMembersSpecification(specParams);
            var countSpec = new BoardWithFiltersForCountSpecification();
            var totalBoards = await _boardRepo.CountAsync(countSpec);
            var boards = await _boardRepo.ListAsync(spec);

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
            return await _boardRepo.GetByIdAsync(boardId);
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
            return boardDetails;
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
        var board = await _boardRepo.GetByIdAsync(boardId);
        if (board == null)
            throw new Exception("Board not found");
        await _boardRepo.DeleteAsync(boardId);
    }

    public void AddPostToBoard(Board board, string postId)
    {
        board.Posts.Add(postId);
        _boardRepo.UpdateAsync(board);
    }

    public async Task UpdateBoardInfo(string boardId, string name, string username, string image)
    {
        try
        {
            var board = await _boardRepo.GetByIdAsync(boardId);

            if (board == null)
                throw new Exception("Board not found");

            board.BoardName = name;
            board.Username = username;
            board.Image = image;

            await _boardRepo.UpdateAsync(board);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
