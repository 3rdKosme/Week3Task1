using System.ComponentModel.DataAnnotations;
using Week3Task1.Models;

namespace Week3Task1.DTOs;

public record CreateAuthorDTO
{
    public string Name { get; set; }
    public DateOnly dateOfBirth { get; set; }
}