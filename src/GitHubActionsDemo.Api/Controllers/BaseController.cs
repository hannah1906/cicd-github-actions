using System.Collections;
using System.Net;
using GitHubActionsDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActionsDemo.Api.Controllers;

public class BaseController : ControllerBase
{
    public IActionResult InternalError()
    {
        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
    }

    public IActionResult PagedResult<T>(int page, int pageSize, T result) where T : IList
    {
        return Ok(new PagedResponse<T>(page, pageSize, result));
    }
}