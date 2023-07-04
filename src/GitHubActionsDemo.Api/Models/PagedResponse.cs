using System.Collections;
namespace GitHubActionsDemo.Api.Models;

public class PagedResponse<T> where T : IList
{
    public PagedResponse(int page, int pageSize, T result)
    {
        Page = page;
        PageSize = pageSize;
        Result = result;
        Count = result.Count;
    }

    public int Page { get; }
    public int PageSize { get; }
    public int Count { get; }
    public T Result { get; }
}