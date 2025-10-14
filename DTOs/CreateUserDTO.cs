using System.ComponentModel.DataAnnotations;
using Week3Task1.Models;

namespace Week3Task1.DTOs;

public record CreateAuthorDTO
{
    [Required, MinLength(2)] string Name;
    public DateOnly dateOfBirth { get; set; }
}