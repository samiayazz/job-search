namespace JobSearch.Application.DTOs.JobPost
{
    public class JobCreateDto(
        string title,
        string position,
        byte yearsOfExperience,
        string description,
        string criteria,
        Guid companyId,
        Guid departmentId,
        Guid workTypeId,
        Guid workModelId)
    {
        public string Title { get; init; } = title;
        public string Position { get; init; } = position;
        public byte YearsOfExperience { get; init; } = yearsOfExperience;
        public string Description { get; init; } = description;
        public string Criteria { get; init; } = criteria;
        public Guid CompanyId { get; init; } = companyId;
        public Guid DepartmentId { get; init; } = departmentId;
        public Guid WorkTypeId { get; init; } = workTypeId;
        public Guid WorkModelId { get; init; } = workModelId;
    }
}