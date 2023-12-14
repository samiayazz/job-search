using JobSearch.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Domain.Entities.Identity;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Address.Address> Addresses { get; set; }
    public AppRole Role { get; set; }
}