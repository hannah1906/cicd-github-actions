namespace GitHubActionsDemo.Persistance;

using GitHubActionsDemo.Persistance.Models;

public interface ILibraryRespository
{
    Task<IEnumerable<BookDb>> GetBooksAsync(int page, int pageSize);
    Task<BookDb> GetBookAsync(int bookId);
    Task<BookDb> AddBookAsync(NewBookDb book);
    Task<AuthorDb> AddAuthorAsync(NewAuthorDb author);
    Task<AuthorDb> GetAuthorAsync(int authorId);
}