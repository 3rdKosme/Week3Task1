using Week3Task1.Models;
using Week3Task1.Repositories.Interfaces;

namespace Week3Task1.Repositories;

public class AuthorRepository(List<Author> authors) : IAuthorRepository
{
    private readonly List<Author> _authors = authors;
    private int _nextId = 1;

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return _authors.ToList().AsReadOnly();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        var user = _authors.FirstOrDefault(x => x.Id == id);
        return user;
    }

    public async Task<int> CreateAsync(Author author)
    {
        author.Id = _nextId++;
        _authors.Add(author);
        return author.Id;
    }

    public async Task<bool> UpdateAsync(Author author)
    {
        int id = _authors.FindIndex(x => x.Id == author.Id);
        if (id != -1) { 
            _authors[id] = author;
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var removed = _authors.RemoveAll(x => x.Id == id) > 0;
        return removed;
    }
}