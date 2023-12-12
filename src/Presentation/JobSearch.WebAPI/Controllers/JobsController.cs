using JobSearch.Application.Contracts.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private IJobRepository _repository;

    public JobsController(IJobRepository repository)
        => _repository = repository;

    [HttpGet("[action]", Name = "JobsGetAll")]
    public IActionResult GetAll()
    {
        return Ok(_repository.GetAll());
    }
}