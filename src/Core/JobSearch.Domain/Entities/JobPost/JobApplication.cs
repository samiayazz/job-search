using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Domain.Entities.JobPost;

public class JobApplication : EntityBase
{
    public Guid JobId { get; set; }
    public virtual Job Job { get; set; }
    public Guid ApplicantId { get; set; }
    public virtual AppUser Applicant { get; set; }
    public string Description { get; set; }
    public decimal SalaryExpection { get; set; }
    public int PeriodOfNotice { get; set; }
}