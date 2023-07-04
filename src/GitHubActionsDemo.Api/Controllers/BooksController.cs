using GitHubActionsDemo.Api.Models;
using GitHubActionsDemo.Api.Mappers;
using GitHubActionsDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionsDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : BaseController
{
    private readonly ILibraryService _libraryService;

    public BooksController(
        ILibraryService libraryService
    )
    {
        _libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
    }

    [HttpGet]
    public async Task<IActionResult> GetBooksAsync([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "pageSize")] int pageSize = 10)
    {
        var result = await _libraryService.GetBooksAsync(page, pageSize);

        return result.Match(
            success => PagedResult(page, pageSize, success.Value.Select(x => x.Map()).ToList()),
            error => InternalError()
        );
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBookAsync(int bookId)
    {
        var result = await _libraryService.GetBookAsync(bookId);
        return result.Match(
            success => Ok(success.Value.Map()),
            notfound => NotFound(),
            error => InternalError()
        );
    }

    [HttpPost]
    public async Task<IActionResult> AddBookAsync([FromBody] BookRequest bookRequest)
    {
        var result = await _libraryService.AddBookAsync(bookRequest.Map());
        return result.Match(
            success => Ok(success.Value.Map()),
            error => InternalError()
        );
    }
}
