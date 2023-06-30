using GitHubActionsDemo.Api.Models;
using GitHubActionsDemo.Api.Mappers;
using GitHubActionsDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionsDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController : ControllerBase
{
    private readonly ILogger<LibraryController> _logger;
    private readonly ILibraryService _libraryService;

    public LibraryController(
        ILogger<LibraryController> logger,
        ILibraryService libraryService
    )
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IEnumerable<BookResponse>> GetBooksAsync(int page = 0, int pageSize = 10)
    {
        var books = await _libraryService.GetBooksAsync(page, pageSize);
        return books.Select(x => x.Map());
    }

    [HttpGet(Name = "GetBook")]
    public async Task<BookResponse> GetBookAsync(int bookId)
    {
        var book = await _libraryService.GetBookAsync(bookId);
        return book.Map();
    }

    [HttpPost(Name = "AddBook")]
    public async Task<BookResponse> AddBookAsync(BookRequest bookRequest)
    {
        var book = await _libraryService.AddBookAsync(bookRequest.Map());
        return book.Map();
    }

    [HttpPost(Name = "AddAuthor")]
    public async Task<AuthorResponse> AddauthorAsync(AuthorRequest authorRequest)
    {
        var author = await _libraryService.AddAuthorAsync(authorRequest.Map());
        return author.Map();
    }
}
