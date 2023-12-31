using API.Dtos;
using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PostsController : BaseApiController
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IReadOnlyList<Post>>> GetPosts([FromQuery] GeneralSpecParams generalParams)
    {
        return Ok(await _postService.GetPosts(generalParams));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostDto>> GetPost(string postId)
    {
        var post = await _postService.GetPostById(postId);

        if (post == null)
            return NotFound(new ApiResponse(404));

        return Ok(post);
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostDto>> AddPost([FromBody] PostRequestDto postForm)
    {
        var post = await _postService.AddPost(postForm);
    
        return Ok(post);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status410Gone)]
    public async Task<ActionResult> DeletePost(string postId)
    {
        await _postService.DeletePost(postId);

        return Ok();
    }
}


