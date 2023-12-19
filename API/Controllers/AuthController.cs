using API.Dtos;
using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController : BaseApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<AppUser>> GetCurrentUser()
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var user = await _authService.GetCurrentUser(token);
        return Ok(user);
    }

    [Authorize]
    [HttpGet("user")]
    public async Task<ActionResult<User>> GetUser()
    {
        var user = _authService.GetUser();
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var auth = await _authService.Login(loginDto.Email, loginDto.Password);
        if (auth == null)
            return Unauthorized(new ApiResponse(401));

        return Ok(auth);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        Console.WriteLine("register vale" + registerDto);
        if (_authService.CheckIfEmailExists(registerDto.Email).Result)
            return new BadRequestObjectResult(
                new ApiValidationErrorResponse { Errors = new[] { "Email address is in use" } }
            );
        var auth = await _authService.SignUp(registerDto.Email, registerDto.Password);
        if (auth == null)
            return BadRequest(new ApiResponse(400));

        return Ok(auth);
    }
}
