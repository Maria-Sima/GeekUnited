using Core.Entities;
using Utilities.Helpers;

namespace Core.Interfaces;

public interface IBoardService
{
    public Task<Board> CreateBoard(string id, string name, string username, string image, string bio, string createdById);

    public Task<Board> AddMembersToBoard(string userId, string boardId);
    
    public Task<Pagination<Board>>  GetBoards(string searchString);

    public Task GetBoardPosts(string id);

    public Task<Board> GetBoardDetails(string boardId);
    public Task RemoveUsersFromBoard(string boardId, string userId);

    public Task DeleteBoard(string boardId);

    public Task UpdateBoardInfo(string boardId, string name, string username, string image);
}
