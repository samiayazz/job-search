namespace JobSearch.Domain.Entities.Common;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}