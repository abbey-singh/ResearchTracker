using Microsoft.EntityFrameworkCore;
using ResearchTrackerApi.Data;
using ResearchTrackerApi.Dtos;
using ResearchTrackerApi.Models;

namespace ResearchTrackerApi.Services
{
    public class ResearchProjectService : IResearchProjectService
    {
        private readonly ResearchTrackerDBContext _context;

        public ResearchProjectService(ResearchTrackerDBContext context)
        {
            _context = context;
        }

        public async Task<List<ResearchProject>> GetAllAsync()
        {
            return await _context.ResearchProjects
                .AsNoTracking()
                .OrderByDescending(project => project.StartDate)
                .ToListAsync();
        }

        public async Task<ResearchProject?> GetByIdAsync(int id)
        {
            return await _context.ResearchProjects
                .AsNoTracking()
                .FirstOrDefaultAsync(project => project.Id == id);
        }

        public async Task<ResearchProject> CreateAsync(
            CreateResearchProjectDto request)
        {
            var project = new ResearchProject
            {
                Title = request.Title,
                ResearcherName = request.ResearcherName,
                Description = request.Description,
                Status = request.Status,
                StartDate = request.StartDate
            };

            _context.ResearchProjects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdateResearchProjectDto request)
        {
            var project = await _context.ResearchProjects.FindAsync(id);

            if (project is null)
            {
                return false;
            }

            project.Title = request.Title;
            project.ResearcherName = request.ResearcherName;
            project.Description = request.Description;
            project.Status = request.Status;
            project.StartDate = request.StartDate;
            project.CompletionDate = request.CompletionDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.ResearchProjects.FindAsync(id);

            if (project is null)
            {
                return false;
            }

            _context.ResearchProjects.Remove(project);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ResearchProject>> GetByStatusAsync(string status)
        {
            return await _context.ResearchProjects
                .AsNoTracking()
                .Where(project => project.Status == status)
                .OrderBy(project => project.Title)
                .ToListAsync();
        }

        public async Task<List<ResearchProject>> SearchAsync(string query)
        {
            return await _context.ResearchProjects
                .AsNoTracking()
                .Where(project =>
                    project.Title.Contains(query) ||
                    project.ResearcherName.Contains(query))
                .OrderBy(project => project.Title)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.ResearchProjects.CountAsync();
        }
    }
}
