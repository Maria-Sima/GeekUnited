namespace API.Dtos;

public record PostRequestDto
{
    public string Text { get; set; }

    public string Description { get; set; }

    public string BoardId { get; set; }

    public string UserId { get; set; }
}
