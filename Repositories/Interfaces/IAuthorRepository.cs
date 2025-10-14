using Week3Task1.Models;

namespace Week3Task1.Repositories.Interfaces;

public interface IAuthorRepository
{
    public Task<IEnumerable<Author>> GetAllAsync();
    public Task<Author?> GetByIdAsync(int id);
    public Task<int> CreateAsync(Author author);
    public Task<bool> UpdateAsync(Author author);
    public Task<bool> DeleteAsync(int id);
}