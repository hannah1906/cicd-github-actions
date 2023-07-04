namespace GitHubActionsDemo.Api.Models;

public class BookResponse
{
    public BookResponse(
        int bookId,
        string title,
        AuthorResponse author,
        string isbn,
        DateTime datePublished,
        DateTime dateCreated,
        DateTime dateModified
    )
    {
        BookId = bookId;
        Title = title;
        Author = author;
        Isbn = isbn;
        DatePublished = datePublished;
        DateCreated = dateCreated;
        DateModified = dateModified;
    }

    public int BookId { get; }
    public string Title { get; }
    public AuthorResponse Author { get; }
    public string Isbn { get; }
    public DateTime DatePublished { get; }
    public DateTime DateCreated { get; }
    public DateTime DateModified { get; }
}
