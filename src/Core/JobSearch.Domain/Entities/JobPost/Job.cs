﻿using JobSearch.Domain.Entities.Common;
using JobSearch.Domain.Entities.Institution;
using JobSearch.Domain.Entities.WorkPreference;

namespace JobSearch.Domain.Entities.JobPost
{
    public class Job : ModifiableEntityBase
    {
        public string Title { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public string Position { get; set; }
        public Guid WorkTypeId { get; set; }
        public virtual WorkType WorkType { get; set; }
        public Guid WorkModelId { get; set; }
        public virtual WorkModel WorkModel { get; set; }
        public byte YearsOfExperience { get; set; }
        public string Description { get; set; }
        public string Criteria { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}