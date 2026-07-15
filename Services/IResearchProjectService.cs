using ResearchTrackerApi.Dtos;
using ResearchTrackerApi.Models;

namespace ResearchTrackerApi.Services
{
    public interface IResearchProjectService
    {
        Task<List<ResearchProject>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<ResearchProject?> GetByIdAsync(int id);
        Task<ResearchProject> CreateAsync(CreateResearchProjectDto request);
        Task<bool> UpdateAsync(int id, UpdateResearchProjectDto request);
        Task<bool> DeleteAsync(int id);

        Task<List<ResearchProject>> GetByStatusAsync(string status);
        Task<List<ResearchProject>> SearchAsync(string query);
    }
}
