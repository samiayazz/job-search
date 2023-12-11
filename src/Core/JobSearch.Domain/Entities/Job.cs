using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities;

public sealed class Job : EntityBase
{
    public string Title { get; set; }
}