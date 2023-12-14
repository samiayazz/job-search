using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Domain.Entities.WorkPreference;

public class WorkType : EntityBase
{
    public string Name { get; set; } // Full-Time, Part-Time, Project-Basis, Intern, Freelance
    public ICollection<Job> Jobs { get; set; }
}