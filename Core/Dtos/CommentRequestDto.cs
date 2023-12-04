namespace API.Dtos;

public class CommentRequestDto
{
    public string UserId { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; }
}
