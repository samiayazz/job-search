using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.Company;

public class Sector : ModifiableEntityBase
{
    public string Name { get; set; }
}