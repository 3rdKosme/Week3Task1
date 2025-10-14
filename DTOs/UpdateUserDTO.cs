using Week3Task1.Models;

namespace Week3Task1.DTOs;

public class UpdateAuthorDTO
{
    public string? Name { get; set; } = null;
    public DateOnly? dateOfBirth { get; set; } = null;
}