using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Domain.Entities.Common;

public abstract class ModifiableEntityBase : EntityBase
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public Guid CreatedById { get; set; }
    public virtual AppUser CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; } = null;
    /*public Guid? UpdatedById { get; set; } = null;
    public AppUser? UpdatedBy { get; set; } = null;*/

    public DateTime? DeletedDate { get; set; } = null;
    /*public Guid? DeletedById { get; set; } = null;
    public AppUser? DeletedBy { get; set; } = null;*/
}