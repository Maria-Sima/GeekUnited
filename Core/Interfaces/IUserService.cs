using API.Dtos;

namespace Core.Interfaces;

public interface IUserService
{
    public Task<UserDto> GetUserById(int id);

    public Task<UserDto> Login(LoginDto loginDto);
    public Task<UserDto> Register(RegisterDto registerDto);
    public Task<bool> CheckEmailExistsAsync(string email);
}