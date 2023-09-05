using API.Dtos;
using API.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MainController : BaseApiController
{
    private readonly IUserService _userService;

    public MainController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("addPost")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostDto>> AddPost([FromBody] PostRequestDto postRequest)
    {
        return Ok(await _userService.AddPost(postRequest));
    }

    [HttpPost("addComment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentDto>> AddCommetn([FromBody] CommentRequestDto requestDto)
    {
        return Ok(await _userService.AddComment(requestDto));
    }

    [HttpPost("subscribeToBoard")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SubscribeBoard([FromBody] string userId, int boardId)
    {
        await _userService.SubscribeToBoard(userId, boardId);

        return NoContent();
    }
}