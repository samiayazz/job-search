namespace JobSearch.Application.DTOs.JobPost;

public class JobCreateDto
{
    public string Title { get; set; }
    public string Position { get; set; }
    public byte YearsOfExperience { get; set; }
    public string Description { get; set; }
    public string Criteria { get; set; }
    public Guid CompanyId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid WorkTypeId { get; set; }
    public Guid WorkModelId { get; set; }
}
