using System.Security.Claims;
using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.Application.Exceptions;
using JobSearch.Domain.Entities.JobPost;
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
        Guid userId = Guid.Empty;
        if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out userId))
            return Unauthorized();

        if (await _service.CreateAsync(userId, job))
            return Ok();
        else
            return Problem();
    }
}