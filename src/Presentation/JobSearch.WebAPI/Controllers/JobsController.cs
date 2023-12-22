using System.Security.Claims;
using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.Application.Exceptions;
using JobSearch.Domain.Entities.JobPost;
using JobSearch.WebAPI.Helpers.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController(IJobService service) : ControllerBase
{
    private IJobService _service = service;

    [HttpPost("create", Name = "CreateJob")]
    public async Task<IActionResult> CreateAsync([FromBody] JobCreateDto job)
    {
        var user = UserHelper.ResolveUserInToken();

        if (await _service.CreateAsync(user.Id, job))
            return Ok();
        else
            return Problem();
    }
}