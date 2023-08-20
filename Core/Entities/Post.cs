namespace Core.Entities;

public class Post:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public Board Board { get; set; }
    public int BoardId{ get; set; }
    // public User User { get; set; }
    // public int UserId { get; set; }
}

