using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PostsController:BaseApiController
{
    private readonly IGenericRepository<Post> _postsRepo;
    private readonly IMapper _mapper;

    public PostsController(IGenericRepository<Post> postsRepo,IMapper mapper)
    {
        _postsRepo = postsRepo;
    }
    [HttpGet("all")]
    public async Task<ActionResult<IReadOnlyList<Post>>> GetPosts()
    {
        return Ok(await _postsRepo.ListAllAsync());
    }
}