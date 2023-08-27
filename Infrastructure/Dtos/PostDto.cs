namespace API.Dtos;

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public string Board { get; set; }
    public string User { get; set; }
}