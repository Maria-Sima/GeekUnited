using Core.Entities;

namespace Core.Interfaces;

public interface IBoardService
{
    public Task AddBoard(string name, string description);

    public Task<Board> AddUsersToBoard(AppUser user, int boardId);

    public Task AddPostToBoard(Post post, Board board);

    public Task<Board> GetBoardById(int boardId);
}