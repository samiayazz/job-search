using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.WorkPreference;

public class WorkModel : EntityBase
{
    public string Name { get; set; } // In-Office, Remote, Hybrid
}