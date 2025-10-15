using Week3Task1.Models;
using Week3Task1.Repositories;
using Week3Task1.DTOs;

namespace Week3Task1.Services.Interfaces;

public interface IAuthorService
{
    public Task<IEnumerable<Author>> GetAllAuthorsAsync();
    public Task<Author?> GetAuthorById(int id);
    public Task<int> AddAuthorAsync(CreateAuthorDTO dto);
    public Task<bool> UpdateAuthorAsync(UpdateAuthorDTO dto, int id);
    public Task<bool> DeleteAuthorAsync(int id);
}