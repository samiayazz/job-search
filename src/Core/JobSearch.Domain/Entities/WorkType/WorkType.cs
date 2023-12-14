using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.WorkType;

public class WorkType : EntityBase
{
    public string Name { get; set; } // Full-Time, Part-Time, Project-Basis, Intern, Freelance
}