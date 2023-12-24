using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.WebAPI.Helpers.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers;

[Authorize(Roles = "Recruiter")]
[Route("api/[controller]")]
[ApiController]
public class JobsController(IJobService service, UserHelper userHelper) : ControllerBase
{
    private readonly IJobService _service = service;
    private readonly UserHelper _userHelper = userHelper;

    [HttpPost("create", Name = "CreateJob")]
    public async Task<IActionResult> CreateAsync([FromBody] JobCreateDto job)
    {
        var user = _userHelper.ResolveUserInToken();

        if (await _service.CreateAsync(user.Id, job))
            return Ok();
        else
            return Problem();
    }
}