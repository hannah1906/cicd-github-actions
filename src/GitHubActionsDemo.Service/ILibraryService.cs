using GitHubActionsDemo.Service.Models;

namespace GitHubActionsDemo.Service;

public interface ILibraryService
{
    Task<IEnumerable<Book>> GetBooksAsync(int page, int pageSize);
    Task<Book> GetBookAsync(int bookId);
    Task<Book> AddBookAsync(NewBook book);
    Task<Author> AddAuthorAsync(NewAuthor author);
}