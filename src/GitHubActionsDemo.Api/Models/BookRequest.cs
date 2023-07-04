namespace GitHubActionsDemo.Api.Models;

public class BookRequest
{
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string Isbn { get; set; }
    public DateTime DatePublished { get; set; }
}
