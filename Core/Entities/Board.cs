namespace Core.Entities;

public class Board : BaseEntity
{
    public string BoardName { get; set; }
    public string Description { get; set; }
    public List<Post> Posts { get; set; } = new();
    public List<AppUser> Subsccribers { get; set; } = new();
}