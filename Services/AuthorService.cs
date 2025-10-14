using Week3Task1.Models;
using Week3Task1.Repositories;
using Week3Task1.Repositories.Interfaces;
using Week3Task1.Services.Interfaces;
using Week3Task1.DTOs;

namespace Week3Task1.Services;

public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    private readonly IAuthorRepository _authorRepository = authorRepository;

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await _authorRepository.GetAllAsync();
    }

    public async Task<Author?> GetAuthorById(int id)
    {
        CheckId(id);
        return await _authorRepository.GetByIdAsync(id);
    }

    public async Task<int> AddAuthorAsync(CreateAuthorDTO dto)
    {
        
    }

    public async Task<bool> UpdateAuthorAsync(UpdateAuthorDTO dto)
    {

    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {

    }

    private static void CheckId(int id)
    {
        if(id <= 0)
        {
            throw new ArgumentException("ID должен быть целым положительным числом.");
        }
    }

}