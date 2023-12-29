using JobSearch.Domain.Entities.Common;

namespace JobSearch.Domain.Entities.Institution
{
    public class Sector : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}