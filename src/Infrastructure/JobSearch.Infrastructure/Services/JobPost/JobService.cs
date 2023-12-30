using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.Contracts.Persistence.Repositories.JobPost;
using JobSearch.Application.Contracts.Persistence.Repositories.User;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Infrastructure.Services.JobPost
{
    public class JobService(IJobRepository repository, IUserRepository userRepository, IMapper mapper) : IJobService
    {
        public async Task<ICollection<Job>?> GetByKeywordAndLocation(string keyword, string location,
            string? department = null, string? workType = null, string? workModel = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(keyword, nameof(keyword));
            ArgumentException.ThrowIfNullOrEmpty(location, nameof(location));

            Func<Job, bool> predicate = job =>
            {
                #region keywordPredicate

                var keywordToSearch = keyword.Trim().ToLower();
                ArgumentException.ThrowIfNullOrEmpty(keywordToSearch, nameof(keywordToSearch));

                if (job.Title.Trim().ToLower().Contains(keywordToSearch))
                    return true;

                if (job.Description.Trim().ToLower().Contains(keywordToSearch))
                    return true;

                if (job.Criteria.Trim().ToLower().Contains(keywordToSearch))
                    return true;

                var company = job.Company.Name.Trim().ToLower();
                if (!string.IsNullOrEmpty(company) && company.Contains(keywordToSearch))
                    return true;

                var position = job.Position.Trim().ToLower();
                if (!string.IsNullOrEmpty(position) && position.Contains(keywordToSearch))
                    return true;

                #endregion

                #region locationPredicate

                var locationToSearch = location.Trim().ToLower();
                ArgumentException.ThrowIfNullOrEmpty(locationToSearch, nameof(locationToSearch));

                var address = job.Company.Address;
                if (address == null)
                    return false;

                var province = address.Province.Name.Trim().ToLower();
                if (!string.IsNullOrEmpty(province) && province.Contains(locationToSearch))
                    return true;

                var district = address.District.Trim().ToLower();
                if (!string.IsNullOrEmpty(district) && district.Contains(locationToSearch))
                    return true;

                var neighborhood = address.Neighborhood?.Trim().ToLower();
                if (!string.IsNullOrEmpty(neighborhood) && neighborhood.Contains(locationToSearch))
                    return true;

                var fullAddress = address.FullAddress?.Trim().ToLower();
                if (!string.IsNullOrEmpty(fullAddress) && fullAddress.Contains(locationToSearch))
                    return true;

                #endregion

                #region departmentPredicate

                var departmentToSearch = department?.Trim().ToLower();
                if (!string.IsNullOrEmpty(departmentToSearch) &&
                    job.Department.Name.Trim().ToLower().Contains(departmentToSearch))
                    return true;

                #endregion

                #region workTypePredicate

                var workTypeToSearch = workType?.Trim().ToLower();
                if (!string.IsNullOrEmpty(workTypeToSearch) &&
                    job.WorkType.Name.Trim().ToLower().Contains(workTypeToSearch))
                    return true;

                #endregion

                #region workModelPredicate

                var workModelToSearch = workModel?.Trim().ToLower();
                if (!string.IsNullOrEmpty(workModelToSearch) &&
                    job.WorkModel.Name.Trim().ToLower().Contains(workModelToSearch))
                    return true;

                #endregion

                return false;
            };

            return await repository.GetAllAsync(job => predicate(job));
        }

        public async Task<bool> CreateAsync(Guid userId, JobModifyDto jobModifyDto)
        {
            var user = await userRepository.FindByIdAsync(userId);
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            if (user.Role.Name is not "Recruiter" and not "Founder")
                throw new Exception(
                    "Sadece 'Recruiter' veya 'Founder' rolündeki üyeler, yeni bir iş ilanı oluşturabilir.");

            var mappedJob = mapper.Map<Job>(jobModifyDto);
            mappedJob.CreatedById = userId;

            return await repository.CreateAsync(mappedJob);
        }

        public async Task<bool> UpdateAsync(Guid userId, Guid jobId, JobModifyDto jobModifyDto)
        {
            var user = await userRepository.FindByIdAsync(userId);
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            var job = await repository.FindByIdAsync(jobId);
            ArgumentNullException.ThrowIfNull(job, nameof(job));

            if ((job.CreatedById == userId || job.Company.Id == user.Company?.Id) &&
                user.Role.Name is not "Recruiter" and not "Founder")
                throw new Exception(
                    "Bir ilanı sadece, ilanın ait olduğu şirkette çalışan ve 'Recruiter' veya 'Founder' rolüne sahip olan üyeler düzenleyebilir.");

            var mappedJob = mapper.Map(jobModifyDto, job);

            return await repository.UpdateAsync(mappedJob);
        }

        public async Task<bool> RemoveAsync(Guid userId, Guid jobId)
        {
            var user = await userRepository.FindByIdAsync(userId);
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            var job = await repository.FindByIdAsync(jobId);
            ArgumentNullException.ThrowIfNull(job, nameof(job));

            if ((job.CreatedById == userId || job.Company.Id == user.Company?.Id) &&
                user.Role.Name is not "Recruiter" and not "Founder")
                throw new Exception(
                    "Bir ilanı sadece, ilanın ait olduğu şirkette çalışan ve 'Recruiter' veya 'Founder' rolüne sahip olan üyeler kaldırabilir.");

            return await repository.RemoveAsync(job);
        }
    }
}