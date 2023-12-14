using JobSearch.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearch.Domain.Entities.Common;

public abstract class ModifiableEntityBase : EntityBase
{
    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public Guid CreatedById { get; set; }
    //[ForeignKey(nameof(CreatedById))]
    public AppUser CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; } = null;
    public Guid? UpdatedById { get; set; } = null;
    //[ForeignKey(nameof(UpdatedById))]
    public AppUser? UpdatedBy { get; set; } = null;

    public DateTime? DeletedDate { get; set; } = null;
    public Guid? DeletedById { get; set; } = null;
    //[ForeignKey(nameof(DeletedById))]
    public AppUser? DeletedBy { get; set; } = null;
}