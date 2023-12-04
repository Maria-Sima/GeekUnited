using Microsoft.AspNetCore.Http;

namespace API.Dtos;

public record PostRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Picture { get; set; }
    public int BoardId { get; set; }
    public string UserId { get; set; }
}
