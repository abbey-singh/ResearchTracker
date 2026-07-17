using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResearchTrackerApi.Dtos;
using ResearchTrackerApi.Models;
using ResearchTrackerApi.Services;

namespace ResearchTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchProjectsController : ControllerBase
    {
        private readonly IResearchProjectService _projectService;
        private readonly ILogger<ResearchProjectsController> _logger;

        public ResearchProjectsController(
            IResearchProjectService projectService,
            ILogger<ResearchProjectsController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        // GET: api/researchprojects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearchProject>>> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        // GET: api/researchprojects/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResearchProject>> GetById(int id)
        {
            var project = await _projectService.GetByIdAsync(id);

            if (project is null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // GET: api/researchprojects/status/In Progress
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<ResearchProject>>> GetByStatus(
            string status)
        {
            var projects = await _projectService.GetByStatusAsync(status);
            return Ok(projects);
        }

        // GET: api/researchprojects/search?query=Abbey
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ResearchProject>>> Search(
            [FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("A search query is required.");
            }

            var projects = await _projectService.SearchAsync(query);

            return Ok(projects);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount()
        {
            var count = await _projectService.GetCountAsync();

            _logger.LogInformation(
                "Research project count requested. Count: {Count}",
                count);

            return Ok(count);
        }

        // POST: api/researchprojects
        [HttpPost]
        public async Task<ActionResult<ResearchProject>> Create(
            CreateResearchProjectDto request)
        {
            _logger.LogInformation(
                "Creating research project with title {Title}",
                request.Title);

            var project = await _projectService.CreateAsync(request);

            _logger.LogInformation(
                "Created research project {ProjectId}",
                project.Id);

            return CreatedAtAction(
                nameof(GetById),
                new { id = project.Id },
                project);
        }

        // PUT: api/researchprojects/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateResearchProjectDto request)
        {
            var updateSuccess = await _projectService.UpdateAsync(id, request);

            if (updateSuccess)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/researchprojects/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteSuccess = await _projectService.DeleteAsync(id);

            if (deleteSuccess)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
