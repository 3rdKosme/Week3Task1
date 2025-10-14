namespace Week3Task1.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateOnly PublishedYear { get; set; }
    public int AuthorId { get; set; }
}