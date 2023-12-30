using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.WebAPI.Helpers.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController(IJobService service, UserHelper userHelper) : ControllerBase
    {
        [HttpGet("{keyword}", Name = "GetJobsByKeywordAndLocation")]
        public async Task<IActionResult> GetByKeywordAndLocation([FromRoute] string keyword,
            [FromQuery] string location,
            [FromQuery] string? department = null, [FromQuery] string? workType = null,
            [FromQuery] string? workModel = null)
        {
            return Ok(await service.GetByKeywordAndLocation(keyword, location, department, workType, workModel));
        }

        [Authorize(Roles = "Recruiter,Founder")]
        [HttpPost("create", Name = "CreateJob")]
        public async Task<IActionResult> CreateAsync([FromBody] JobModifyDto job)
        {
            var user = userHelper.ResolveUserInToken();

            var result = await service.CreateAsync(user.Id, job);
            if (!result)
                return Problem();

            return Ok();
        }

        [Authorize(Roles = "Recruiter,Founder")]
        [HttpPost("update/{id}", Name = "UpdateJob")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] JobModifyDto jobModifyDto)
        {
            var user = userHelper.ResolveUserInToken();

            var result = await service.UpdateAsync(user.Id, id, jobModifyDto);
            if (!result)
                return Problem();

            return Ok();
        }

        [Authorize(Roles = "Recruiter,Founder")]
        [HttpGet("remove/{id}", Name = "RemoveJob")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var user = userHelper.ResolveUserInToken();

            var result = await service.RemoveAsync(user.Id, id);
            if (!result)
                return Problem();

            return Ok();
        }
    }
}