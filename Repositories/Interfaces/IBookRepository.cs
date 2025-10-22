using Week3Task1.Models;

namespace Week3Task1.Repositories.Interfaces;

public interface IBookRepository
{
    public IEnumerable<Book> GetAll();
    public Book? GetById(int id);
    public int Create(Book book);
    public bool Update(Book book);
    public bool Delete(int id);
}