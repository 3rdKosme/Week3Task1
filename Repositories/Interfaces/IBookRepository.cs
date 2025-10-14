using Week3Task1.Models;

namespace Week3Task1.Repositories.Interfaces;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task<Book?> GetByIdAsync(int id);
    public Task<int> CreateAsync(Book book);
    public Task<bool> UpdateAsync(Book book);
    public Task<bool> DeleteAsync(int id);
}