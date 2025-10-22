using Week3Task1.Models;
using Week3Task1.Repositories;
using Week3Task1.DTOs;

namespace Week3Task1.Services.Interfaces;

public interface IAuthorService
{
    public IEnumerable<Author> GetAllAuthors();
    public Author? GetAuthorById(int id);
    public int AddAuthor(CreateAuthorDTO dto);
    public bool UpdateAuthor(UpdateAuthorDTO dto, int id);
    public bool DeleteAuthor(int id);
}