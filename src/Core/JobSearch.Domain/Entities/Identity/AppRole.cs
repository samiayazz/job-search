using Microsoft.AspNetCore.Identity;

namespace JobSearch.Domain.Entities.Identity;

public class AppRole : IdentityRole<Guid> // Worker, Recruiter, Founder
{
    public override Guid Id { get; set; }
    public override string Name { get; set; }
    public virtual ICollection<AppUser> Users { get; set; }
}