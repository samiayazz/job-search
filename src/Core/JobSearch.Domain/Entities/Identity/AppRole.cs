using Microsoft.AspNetCore.Identity;

namespace JobSearch.Domain.Entities.Identity;

public class AppRole : IdentityRole<Guid>
{
    // Worker, Recruiter, Founder
    public ICollection<AppUser> Users { get; set; }
}