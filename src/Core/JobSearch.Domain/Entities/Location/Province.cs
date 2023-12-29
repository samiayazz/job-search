using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.Location
{
    public class Province : EntityBase
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}