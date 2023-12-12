namespace API.Dtos;

public record NewUserRequest
{
    public string Username { get; set; }

    public string? ProfilePhoto { get; set; }

    public string Name { get; set; }

    public string Bio { get; set; }
}
