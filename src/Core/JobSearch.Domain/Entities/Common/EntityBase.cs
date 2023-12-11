using JobSearch.Application.Contracts.Domain;

namespace JobSearch.Domain.Entities.Common;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedDate { get; private init; } = DateTime.Now;
    public string CreatedBy { get; private init; } = "postgres";

    public DateTime? UpdatedDate { get; set; } = null;
    public string? UpdatedBy { get; set; } = null;

    public DateTime? DeletedDate { get; set; } = null;
    public string? DeletedBy { get; set; } = null;
}