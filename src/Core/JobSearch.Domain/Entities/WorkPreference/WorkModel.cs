using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Domain.Entities.WorkPreference;

public class WorkModel : EntityBase
{
    public string Name { get; set; }
    public ICollection<Job> Jobs { get; set; }
}