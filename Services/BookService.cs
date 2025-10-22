using Week3Task1.Models;
using Week3Task1.Services.Interfaces;
using Week3Task1.Repositories.Interfaces;
using Week3Task1.Helpers;
using Week3Task1.DTOs;

namespace Week3Task1.Services;

public class BookService(IBookRepository bookRepository, IAuthorRepository authorRepository) : IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly IAuthorRepository _authorRepository = authorRepository;

    public IEnumerable<Book> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }

    public Book? GetBookById(int id)
    {
        ValidationHelper.CheckId(id);
        return _bookRepository.GetById(id);
    }

    public int AddBook(CreateBookDTO dto)
    {
        CheckAuthor(dto.AuthorId);
        CheckYear(dto.PublishedYear);
        var book = new Book
        {
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            AuthorId = dto.AuthorId
        };
        return _bookRepository.Create(book);
    }

    public bool UpdateBook(UpdateBookDTO dto, int id)
    {
        var existingBook = _bookRepository.GetById(id);

        if (existingBook == null)
        {
            throw new ArgumentNullException($"����� � ����� Id (id = {id}) �� ����������.");
        }

        if(dto.Title is not null)
        {
            existingBook.Title = dto.Title;
        }
        if (dto.PublishedYear is not null)
        {
            CheckYear((int)dto.PublishedYear);
            existingBook.PublishedYear = (int)dto.PublishedYear;
        }
        if(dto.AuthorId is not null)
        {
            CheckAuthor((int)dto.AuthorId);
            existingBook.AuthorId = (int)dto.AuthorId;
        }

        return _bookRepository.Update(existingBook);
    }

    public bool DeleteBook(int id)
    {
        ValidationHelper.CheckId(id);
        return _bookRepository.Delete(id);
    }

    private void CheckAuthor(int id)
    {
        if(!_authorRepository.Exists(id))
        {
            throw new ArgumentNullException($"������ � Id = {id} �� ����������.");
        }
    }

    private void CheckYear(int year)
    {
        if(year > DateTime.UtcNow.Year)
        {
            throw new ArgumentException($"������������ ��� ����������.");
        }
    }
}