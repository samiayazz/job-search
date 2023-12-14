using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.WorkType;

public class WorkModel : EntityBase
{
    public string Name { get; set; } // In-Office, Remote, Hybrid
}