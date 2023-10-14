using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProjectsController : ControllerBase
    {

        private readonly ILogger<ProjectsController> _logger;
        private readonly ChayProjectsContext _context;

        public ProjectsController(ChayProjectsContext context, ILogger<ProjectsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get all projects within the database
        /// </summary>
        /// <returns>All projects within the project database</returns>
        /// <response code="200">Returns 200 and all projects</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            return _context.Projects.Include(p => p.Descriptions).ToList();
        }

        /// <summary>
        /// Get specified project from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specified project</returns>
        /// /// <response code="200">Returns 200 and specified project</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Project> GetProject(int id) {
            var project = _context.Projects.Include(p => p.Descriptions).FirstOrDefault(x => x.ProjectId==id);
            if (project == null)
            {
                return NotFound();
            }
            return project;
        }
    }
}