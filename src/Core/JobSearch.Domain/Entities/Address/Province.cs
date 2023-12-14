using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.Address;

public class Province : EntityBase
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
}