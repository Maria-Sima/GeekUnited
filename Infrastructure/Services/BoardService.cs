using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services;

public class BoardService : IBoardService
{
    private readonly IGenericRepository<Board> _boardRepo;

    public BoardService(IGenericRepository<Board> boardRepo)
    {
        _boardRepo = boardRepo;
    }

    public async Task AddBoard(string name, string description)
    {
        var newBoard = new Board
        {
            Description = description,
            BoardName = name
        };

        _boardRepo.Add(newBoard);
        _boardRepo.SaveChangesAsync();
    }

    public async Task AddPostToBoard(Post post, Board board)
    {
        board.Posts.Add(post);
        _boardRepo.SaveChangesAsync();
    }

    public Task<Board> GetBoardById(int boardId)
    {
        return _boardRepo.GetByIdAsync(boardId);
    }

    public async Task AddUsersToBoard(AppUser user, int boardId)
    {
        var board = await _boardRepo.GetByIdAsync(boardId);
        if (board == null) throw new Exception("Board doesnt exist");

        board.Subsccribers.Add(user);
        _boardRepo.SaveChangesAsync();
    }
}