using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    // [Authorize]
    // [HttpGet]
    // public async Task<ActionResult<UserDto>> GetCurrentUser()
    // {
    //     var user = await _userService.GetCurrentUser(HttpContext.User);
    //     return Ok(user);
    // }
    //

    [HttpPut("onboarding")]
    public async Task<ActionResult<UserDto>> Register(NewUserRequest registerDto)
    {
        var user = await _userService.OnboardUser(registerDto);
        if (user == null)
            return BadRequest(new ApiResponse(400));

        return Ok(user);
    }
}
