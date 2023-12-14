using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.JobPost;

public class Department : EntityBase
{
    public string Name { get; set; }
    public ICollection<Job> Jobs { get; set; }
}