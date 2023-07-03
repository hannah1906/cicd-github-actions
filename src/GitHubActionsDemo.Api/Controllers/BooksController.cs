using GitHubActionsDemo.Api.Models;
using GitHubActionsDemo.Api.Mappers;
using GitHubActionsDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionsDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly ILibraryService _libraryService;

    public BooksController(
        ILogger<BooksController> logger,
        ILibraryService libraryService
    )
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
    }

    [HttpGet]
    public async Task<IEnumerable<BookResponse>> GetBooksAsync(int page = 0, int pageSize = 10)
    {
        var books = await _libraryService.GetBooksAsync(page, pageSize);
        return books.Select(x => x.Map());
    }

    [HttpGet("{bookId}")]
    public async Task<BookResponse> GetBookAsync(int bookId)
    {
        var book = await _libraryService.GetBookAsync(bookId);
        return book.Map();
    }

    [HttpPost]
    public async Task<BookResponse> AddBookAsync(BookRequest bookRequest)
    {
        var book = await _libraryService.AddBookAsync(bookRequest.Map());
        return book.Map();
    }
}
