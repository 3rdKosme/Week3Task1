using Week3Task1.Models;
using Week3Task1.Repositories.Interfaces;

namespace Week3Task1.Repositories;

public class BookRepository(List<Book> books) : IBookRepository
{
    private readonly List<Book> _books = books;

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return _books.ToList().AsReadOnly();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);
        return book;
    }

    public async Task<int> CreateAsync(Book book)
    {
        _books.Add(book);
        int id = _books.FirstOrDefault(x => x.Id == book.Id).Id;
        return id;
    }

    public async Task<bool> UpdateAsync(Book book)
    {
        int id = _books.FindIndex(x => x.Id == book.Id);
        if (id != -1)
        {
            _books[id] = book;
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        int idInList = _books.FindIndex(x => x.Id == id);
        if (idInList != -1)
        {
            _books.RemoveAt(idInList);
            return true;
        }
        return false;
    }
}