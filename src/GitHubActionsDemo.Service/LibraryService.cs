using GitHubActionsDemo.Persistance;
using GitHubActionsDemo.Service.Mappers;
using GitHubActionsDemo.Service.Models;

namespace GitHubActionsDemo.Service;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRespository _libraryRepository;

    public LibraryService(ILibraryRespository libraryRepository)
    {
        _libraryRepository = libraryRepository ?? throw new ArgumentNullException(nameof(libraryRepository));
    }

    public async Task<Author> AddAuthorAsync(NewAuthor newAuthor)
    {
        var author = await _libraryRepository.AddAuthorAsync(newAuthor.Map());
        return author.Map();
    }

    public async Task<Book> AddBookAsync(NewBook newBook)
    {
        var book = await _libraryRepository.AddBookAsync(newBook.Map());
        return book.Map();
    }

    public async Task<Book> GetBookAsync(int bookId)
    {
        var book = await _libraryRepository.GetBookAsync(bookId);
        return book.Map();
    }

    public async Task<IEnumerable<Book>> GetBooksAsync(int page, int pageSize)
    {
        var books = await _libraryRepository.GetBooksAsync(page, pageSize);
        return books?.Select(book => book.Map()) ?? new List<Book>();
    }
}