namespace GitHubActionsDemo.Api.Models;

public class AuthorResponse
{
    public AuthorResponse(
        int authorId,
        string firstName,
        string lastName,
        DateTime dateCreated,
        DateTime dateModified
    )
    {
        AuthorId = authorId;
        FirstName = firstName;
        LastName = lastName;
        DateCreated = dateCreated;
        DateModified = dateModified;
    }

    public int AuthorId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateCreated { get; }
    public DateTime DateModified { get; }
}
