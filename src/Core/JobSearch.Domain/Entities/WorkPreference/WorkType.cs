using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Domain.Entities.WorkPreference
{
    public class WorkType : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}