using Core.Entities;
using Core.Specifications;
using Utilities.Helpers;

namespace Core.Interfaces;

public interface IBoardService
{
    public Task<Board> CreateBoard(string id, string name, string username, string image, string bio, string createdById);

    public Task<Board> AddMembersToBoard(string userId, string boardId);

    public Task<Pagination<Board>> GetBoards(GeneralSpecParams specParams);

    public Task GetBoardPosts(string id);

    public Task<Board> GetBoardDetails(string boardId);
    public Task RemoveUsersFromBoard(string boardId, string userId);

    public Task DeleteBoard(string boardId);
    public void AddPostToBoard(Board board, string postId);
    public Task UpdateBoardInfo(string boardId, string name, string username, string image);
    public Task<Board> GetBoardById(string boardId);
}
