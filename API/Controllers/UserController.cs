using AutoMapper;
using Core.Interfaces;

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
    // [HttpPost("login")]
    // public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    // {
    //     var user = await _userService.Login(loginDto);
    //     if (user == null)
    //         return Unauthorized(new ApiResponse(401));
    //
    //     return Ok(user);
    // }
    //
    // [HttpPost("register")]
    // public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    // {
    //     Console.WriteLine("register vale" + registerDto);
    //     if (_userService.CheckEmailExistsAsync(registerDto.Email).Result)
    //         return new BadRequestObjectResult(
    //             new ApiValidationErrorResponse { Errors = new[] { "Email address is in use" } }
    //         );
    //     var user = await _userService.Register(registerDto);
    //     if (user == null)
    //         return BadRequest(new ApiResponse(400));
    //
    //     return Ok(user);
    // }
}
