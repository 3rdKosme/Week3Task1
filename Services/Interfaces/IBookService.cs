using Week3Task1.Models;
using Week3Task1.DTOs;

namespace Week3Task1.Services.Interfaces;

public interface IBookService
{
    public IEnumerable<Book> GetAllBooks();
    public Book? GetBookById(int id);
    public int AddBook(CreateBookDTO dto);
    public bool UpdateBook(UpdateBookDTO dto, int id);
    public bool DeleteBook(int id);
}