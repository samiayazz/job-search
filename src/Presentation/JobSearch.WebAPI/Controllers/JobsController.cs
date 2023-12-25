using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.WebAPI.Helpers.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController(IJobService service, UserHelper userHelper) : ControllerBase
{
    [HttpGet("{keyword}", Name = "GetJobsByKeyword")]
    public async Task<IActionResult> GetByKeyword([FromRoute] string keyword, [FromQuery] string location,
        [FromQuery] string? department = null, [FromQuery] string? workType = null, [FromQuery] string? workModel = null)
        => Ok(await service.GetByKeywordAndLocation(keyword, location, department, workType, workModel));

    [Authorize(Roles = "Recruiter,Founder")]
    [HttpPost("create", Name = "CreateJob")]
    public async Task<IActionResult> CreateAsync([FromBody] JobCreateDto job)
    {
        var user = userHelper.ResolveUserInToken();

        var result = await service.CreateAsync(user.Id, job);
        if (!result)
            return Problem();

        return Ok();
    }
}