using Week3Task1.Models;

namespace Week3Task1.Repositories.Interfaces;

public interface IAuthorRepository
{
    public IEnumerable<Author> GetAll();
    public Author? GetById(int id);
    public int Create(Author author);
    public bool Update(Author author);
    public bool Delete(int id);
    public bool Exists(int id);
}