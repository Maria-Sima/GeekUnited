using API.Dtos;
using API.Errors;
using Core.Entities;
using Core.Specifications;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PostsController:BaseApiController
{
    private readonly PostService _postService;

    public PostsController(PostService postService)
    {
        _postService = postService;
    }


    [HttpGet("all")]
    public async Task<ActionResult<IReadOnlyList<Post>>> GetPosts([FromQuery]PostSpecParams postParams)
    {
        return Ok(await _postService.GetPosts(postParams));
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostDto>> GetPost(int id)
    {


        var post = await _postService.GetPost(id);

        if (post == null) return NotFound(new ApiResponse(404));

        return post;
    }

}