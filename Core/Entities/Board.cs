namespace Core.Entities;

public class Board : BaseEntity
{
    public string BoardName { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public IReadOnlyList<Post> Posts { get; set; }
}