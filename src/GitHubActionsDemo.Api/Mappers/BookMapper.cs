using GitHubActionsDemo.Api.Models;
using GitHubActionsDemo.Service.Models;

namespace GitHubActionsDemo.Api.Mappers;

public static class BookMapper
{
    public static NewBook Map(this BookRequest request)
    {
        return new NewBook(
            request.Title,
            request.AuthorId,
            request.Isbn,
            request.DatePublished
        );
    }

    public static BookResponse Map(this Book book)
    {
        return new BookResponse(
            book.BookId,
            book.Title,
            book.Author.Map(),
            book.Isbn,
            book.DatePublished,
            book.DateCreated,
            book.DateModified
        );
    }
}