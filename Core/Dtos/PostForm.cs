using Microsoft.AspNetCore.Http;

namespace API.Dtos;

public record PostForm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Picture { get; set; }
    public int BoardId { get; set; }
    public int UserId { get; set; }
}