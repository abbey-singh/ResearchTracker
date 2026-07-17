using Microsoft.EntityFrameworkCore;
using ResearchTrackerApi.Models;

namespace ResearchTrackerApi.Data
{
    public class ResearchTrackerDBContext : DbContext
    {
        public ResearchTrackerDBContext(
            DbContextOptions<ResearchTrackerDBContext> options)
            : base(options) {}

        public DbSet<ResearchProject> ResearchProjects => Set<ResearchProject>();
    }
}
