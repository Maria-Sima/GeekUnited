using API.Dtos;
using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BoardController:BaseApiController
{
    private readonly IBoardService _boardService;
    public BoardController(IBoardService boardService)
    {
        _boardService = boardService;
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IReadOnlyList<Board>>> GetBoards([FromQuery] GeneralSpecParams generalParams)
    {
        Console.WriteLine(generalParams);
        return Ok(await _boardService.GetBoards(generalParams));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Board>> GetBoard(string boardId)
    {
        var board = await _boardService.GetBoardById(boardId);

        if (board == null)
            return NotFound(new ApiResponse(404));

        return Ok(board);
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Board>> AddBoard([FromBody]  string id, string name, string username, string image, string bio, string createdById)
    {
        var board = await _boardService.CreateBoard(id,name,username,image,bio,createdById);
    
        return Ok(board);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status410Gone)]
    public async  Task<ActionResult> DeleteBoard(string boardId)
    {
       await _boardService.DeleteBoard(boardId);

        return Ok();
    }
}
