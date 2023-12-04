using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public record RegisterDto
{
    [Required]
    public string DisplayName { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [RegularExpression(
        "(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+}{\":;'?/.,])(?!.*\\s).*$",
        ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters"
    )]
    public string Password { get; init; }
}
