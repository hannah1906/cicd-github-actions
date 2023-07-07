using GitHubActionsDemo.Api.Contract;
using GitHubActionsDemo.Api.Models;
using GitHubActionsDemo.Service.Models;

namespace GitHubActionsDemo.Api.Mappers;

public static class AuthorMapper
{
    public static NewAuthor Map(this AuthorRequest request)
    {
        return new NewAuthor(
            request.FirstName,
            request.LastName
        );
    }

    public static AuthorResponse Map(this Author author)
    {
        return new AuthorResponse(
            author.AuthorId,
            author.FirstName,
            author.LastName,
            author.DateCreated,
            author.DateModified
        );
    }
}