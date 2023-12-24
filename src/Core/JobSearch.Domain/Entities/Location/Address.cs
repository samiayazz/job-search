using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.Institution;

namespace JobSearch.Domain.Entities.Location;

public class Address : ModifiableEntityBase
{
    public string Title { get; set; }
    public string District { get; set; }
    public string? Neighborhood { get; set; }
    public string? FullAddress { get; set; }
    public Guid ProvinceId { get; set; }
    public virtual Province Province { get; set; }
    public Guid? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}