using Core.Entities;
using Core.Interfaces;

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
            await _userService.AddBoardCreatedByUser(id, user);

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
                throw new Exception("User is already a member of this boar");
            board.Members.Add(user.Id);

            return board;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task GetBoards(string searchString)
    {
        throw new NotImplementedException();
    }

    public Task GetBoardPosts(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Board> GetBoardDetails(string boardId)
    {
        throw new NotImplementedException();
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
          await  _userService.RemoveBoardFromUser(boardId, userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task DeleteBoard(string boardId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBoardInfo(string boardId, string name, string username, string image)
    {
        throw new NotImplementedException();
    }
}
