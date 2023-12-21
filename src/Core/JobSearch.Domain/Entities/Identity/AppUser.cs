using JobSearch.Domain.Entities.Institution;
using JobSearch.Domain.Entities.JobPost;
using JobSearch.Domain.Entities.Location;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Domain.Entities.Identity;

public class AppUser : IdentityUser<Guid>
{
    public override Guid Id { get; set; }
    public override string UserName { get; set; }
    public override string Email { get; set; }
    public override string PasswordHash { get; set; }
    public override string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid RoleId { get; set; }
    public AppRole Role { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<JobApplication> JobApplications { get; set; }
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }
    public ICollection<Job>? Jobs { get; set; }
}