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
    public async Task<ActionResult<IReadOnlyList<Post>>> GetPosts([FromQuery] PostSpecParams postParams)
    {
        return Ok(await _postService.GetPosts(postParams));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostDto>> GetPost(int id)
    {
        var post = await _postService.GetPost(id);

        if (post == null)
            return NotFound(new ApiResponse(404));

        return post;
    }

    // [HttpPost("add")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    // public async Task<ActionResult<PostDto>> AddPost([FromBody] PostForm postForm)
    // {
    //     var post = await _postService.AddPost(postF);
    //
    //     return Ok(post);
    // }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status418ImATeapot)]
    public async Task<ActionResult> DeletePost(int id)
    {
        await _postService.DeletePost(id);

        return Ok();
    }
}
