namespace Core.Entities;

public class Post : BaseEntity
{
    public string Text { get; set; }

    public string Description { get; set; }

    public string PictureUrl { get; set; }

    public string Board { get; set; }


    public string Author { get; set; }

    public string ParentId { get; set; }

    public List<string> Children { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
