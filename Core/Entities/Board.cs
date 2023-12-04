namespace Core.Entities;

public class Board : BaseEntity
{
    public string BoardName { get; set; }

    public string Username { get; set; }

    public string Bio { get; set; }

    public string Image { get; set; }

    public string CreatedBy { get; set; }
    public List<string> Posts { get; set; } = new();

    public List<string> Members { get; set; } = new();
}
