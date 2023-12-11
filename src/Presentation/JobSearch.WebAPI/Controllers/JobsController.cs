using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    [HttpGet("/[action]", Name = "GetAllJobs")]
    public IActionResult Get()
    {
        return Ok();
    }
}