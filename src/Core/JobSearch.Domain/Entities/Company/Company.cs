using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.Company;

public class Company : ModifiableEntityBase
{
    public string Name { get; set; }
    public Sector Sector { get; set; }
    public Address.Address Address { get; set; }
    public string? Description { get; set; }
}