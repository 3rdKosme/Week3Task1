using Week3Task1.Models;
using Week3Task1.Repositories;
using Week3Task1.Repositories.Interfaces;
using Week3Task1.Services.Interfaces;
using Week3Task1.DTOs;
using Microsoft.AspNetCore.Mvc.Formatters;

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
        var author = new Author
        {
            Name = dto.Name,
            DateOfBirth = dto.dateOfBirth
        };
        return await _authorRepository.CreateAsync(author);
    }

    public async Task<bool> UpdateAuthorAsync(UpdateAuthorDTO dto, int id)
    {
        CheckId(id);
        var existingAuthor = await _authorRepository.GetByIdAsync(id);

        if (existingAuthor == null) {
            throw new ArgumentNullException($"Автора с ID = {id} не существует.");
        }

        if(dto.Name is not null)
        {
            existingAuthor.Name = dto.Name;
        }

        if(dto.dateOfBirth is not null)
        {
            existingAuthor.DateOfBirth = (DateOnly)dto.dateOfBirth;
        }

        return await _authorRepository.UpdateAsync(existingAuthor);
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        CheckId(id);
        return await _authorRepository.DeleteAsync(id);
    }

    private static void CheckId(int id)
    {
        if(id <= 0)
        {
            throw new ArgumentException("ID должен быть целым положительным числом.");
        }
    }


}