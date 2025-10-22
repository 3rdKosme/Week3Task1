using System.ComponentModel.DataAnnotations;

namespace Week3Task1.DTOs;

public record CreateAuthorDTO
{
    [Required]
    [MinLength(2)]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required] 
    public DateOnly DateOfBirth { get; set; }
}