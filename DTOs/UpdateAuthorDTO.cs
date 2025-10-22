using System.ComponentModel.DataAnnotations;

namespace Week3Task1.DTOs;

public record UpdateAuthorDTO
{
    [MinLength(2)]
    [MaxLength(200)]
    public string? Name { get; set; } = null;
    public DateOnly? DateOfBirth { get; set; } = null;
}