namespace API.Dtos;

public record PostDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string PictureUrl { get; init; }
    public string Board { get; init; }
    public string User { get; init; }
}