using Microsoft.AspNetCore.Http;

namespace API.Dtos;

public record NewUserRequest
{
    public string UserID { get; set; }

    public string Username { get; set; }

    public IFormFile? ProfilePhoto { get; set; }

    public string Name { get; set; }

    public string Bio { get; set; }
}
