using System.ComponentModel.DataAnnotations;

namespace Week3Task1.DTOs;

public record UpdateBookDTO
{
    [MinLength(2)]
    [MaxLength(200)]
    public string? Title { get; set; } = null;
    [Range(1, 3000)]
    public int? PublishedYear { get; set; } = null;
    [Range(1, Int32.MaxValue)]
    public int? AuthorId { get; set; } = null;
}