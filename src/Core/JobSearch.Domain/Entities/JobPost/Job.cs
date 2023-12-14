using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.Identity;
using JobSearch.Domain.Entities.Institution;
using JobSearch.Domain.Entities.WorkPreference;

namespace JobSearch.Domain.Entities.JobPost;

public sealed class Job : ModifiableEntityBase
{
    public string Title { get; set; } // Junior .NET Developer
    public Company Company { get; set; }
    public Department Department { get; set; }
    public string Position { get; set; }
    public WorkType WorkType { get; set; }
    public WorkModel WorkModel { get; set; }
    public byte YearsOfExperience { get; set; } // Min: 0 | Max: 255
    public string Description { get; set; }
    public string Criteria { get; set; }
    public IQueryable<AppUser> Applicants { get; set; }
}