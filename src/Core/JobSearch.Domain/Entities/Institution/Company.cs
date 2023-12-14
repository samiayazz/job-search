using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.JobPost;
using JobSearch.Domain.Entities.Location;

namespace JobSearch.Domain.Entities.Institution;

public class Company : ModifiableEntityBase
{
    public string Name { get; set; }
    public Guid SectorId { get; set; }
    public Sector Sector { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public string? Description { get; set; }
    public ICollection<Job> Jobs { get; set; }
}