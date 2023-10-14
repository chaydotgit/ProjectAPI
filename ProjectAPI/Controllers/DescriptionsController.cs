using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models;

namespace ProjectsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DescriptionsController : ControllerBase
    {
        private readonly ChayProjectsContext _context;

        public DescriptionsController(ChayProjectsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Description>> GetDescriptions()
        {
            return _context.Descriptions.ToList();
        }

        [HttpGet("project/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Description>> GetProjectDescription(int projectId)
        {
            var projectDescription = _context.Descriptions.Where(d => d.ProjectId == projectId).ToList();
            if (projectDescription == null)
            {
                return NotFound();
            }
            return projectDescription;
        }
    }
}
