namespace GitHubActionsDemo.Persistance.Models;

public class BookDb
{
    public BookDb(
        int bookId,
        string title,
        AuthorDb author,
        string isbn,
        DateOnly datePublished,
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
    public AuthorDb Author { get; }
    public string Isbn { get; }
    public DateOnly DatePublished { get; }
    public DateTime DateCreated { get; }
    public DateTime DateModified { get; }
}
