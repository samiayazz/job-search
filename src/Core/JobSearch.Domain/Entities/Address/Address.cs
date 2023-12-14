using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.Address;

public class Address : ModifiableEntityBase
{
    public string Title { get; set; }
    public string District { get; set; }
    public string? Neighborhood { get; set; }
    public string? FullAddress { get; set; }
    public Province Province { get; set; }
}