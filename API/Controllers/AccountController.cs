using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public AccountController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    // [Authorize]
    // [HttpGet]
    // public async Task<ActionResult<UserDto>> GetCurrentUser()
    // {
    //     var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
    //
    //     return new UserDto
    //     {
    //         Email = user.Email,
    //         Token = _tokenService.CreateToken(user),
    //         DisplayName = user.UserName
    //     };
    // }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = _userService.Login(loginDto);
        if (user==null)
        { 
            return Unauthorized(new ApiResponse(401));
        }

        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (_userService.CheckEmailExistsAsync(registerDto.Email).Result)
            return new BadRequestObjectResult(new ApiValidationErrorResponse
                { Errors = new[] { "Email address is in use" } });
        var user = _userService.Register(registerDto);
        if (user.IsCompletedSuccessfully)
        {
            return BadRequest(new ApiResponse(400));
        }

        return Ok(user);
    }
}