using GitHubActionsDemo.Api.Models;
using GitHubActionsDemo.Api.Mappers;
using GitHubActionsDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionsDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController : BaseController
{
    private readonly ILibraryService _libraryService;

    public AuthorsController(
        ILibraryService libraryService
    )
    {
        _libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorRequest authorRequest)
    {
        var result = await _libraryService.AddAuthorAsync(authorRequest.Map());
        return result.Match(
            success => Ok(success.Value.Map()),
            error => InternalError()
        );
    }

    [HttpGet("{authorId}")]
    public async Task<IActionResult> GetAuthorAsync(int authorId)
    {
        var result = await _libraryService.GetAuthorAsync(authorId);
        return result.Match(
            success => Ok(success.Value.Map()),
            notfound => NotFound(),
            error => InternalError()
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthorsAsync([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "pageSize")] int pageSize = 10)
    {
        var result = await _libraryService.GetAuthorsAsync(page, pageSize);

        return result.Match(
            success => PagedResult(page, pageSize, success.Value.Select(x => x.Map()).ToList()),
            error => InternalError()
        );
    }
}
