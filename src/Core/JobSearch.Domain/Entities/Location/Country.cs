using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.Location
{
    public class Country : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}