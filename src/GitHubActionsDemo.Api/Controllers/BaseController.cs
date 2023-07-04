using System.Collections;
using System.Net;
using GitHubActionsDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionsDemo.Api.Controllers;

public class BaseController : ControllerBase
{
    public IResult InternalError()
    {
        return Results.StatusCode((int)HttpStatusCode.InternalServerError);
    }

    public IResult PagedResult<T>(int page, int pageSize, T result) where T : IList
    {
        return Results.Ok(new PagedResponse<T>(page, pageSize, result));
    }
}