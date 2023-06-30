using GitHubActionsDemo.Persistance.Models;

namespace GitHubActionsDemo.Persistance;

public class LibraryRespository : ILibraryRespository
{
    public LibraryRespository()
    {

    }

    public async Task<AuthorDb> AddAuthorAsync(NewAuthorDb author)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorDb> GetAuthorAsync(int authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDb> AddBookAsync(NewBookDb book)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDb> GetBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookDb>> GetBooksAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}
