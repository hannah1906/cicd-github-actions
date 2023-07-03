using GitHubActionsDemo.Api.Models;
using GitHubActionsDemo.Api.Mappers;
using GitHubActionsDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionsDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ILogger<AuthorsController> _logger;
    private readonly ILibraryService _libraryService;

    public AuthorsController(
        ILogger<AuthorsController> logger,
        ILibraryService libraryService
    )
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
    }

    [HttpPost]
    public async Task<AuthorResponse> AddAuthorAsync(AuthorRequest authorRequest)
    {
        var author = await _libraryService.AddAuthorAsync(authorRequest.Map());
        return author.Map();
    }
}
