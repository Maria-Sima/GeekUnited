namespace Core.Entities;

public class Comment : BaseEntity
{
    public string CommentText { get; set; }
    public Post Post { get; set; }
    public int PostId { get; set; }
    public AppUser User { get; set; }
    public string UserId { get; set; }
}