using Microsoft.AspNetCore.Mvc;

using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProject<Project> _project;
        public ProjectsController(IProject<Project> project)
        {
            _project = project;
        }
        // GET: api/<ProjectsController>
        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
        {
            try
            {
                return await _project.GetAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<Project> Get(int id)
        {
            try
            {
                return await _project.GetById(id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            if (project != null)
            {
                Project p = await _project.Create(project);
                if (p != null)
                    return Ok(p);
                return BadRequest();
            }
            return BadRequest();
        }

        // PUT api/<ProjectsController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        //public void Put(int id, [FromBody] string value)
        public async Task<ActionResult<Project>> Put(Project project)
        {
            if (project != null)
            {
                Project p = await _project.Update(project);
                if (p != null)
                    return Ok(p);
                return BadRequest();
            }
            return BadRequest();
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if(id>0)
            {
                bool deleted = await _project.Delete(id);
                if (deleted == true)
                    return NoContent();
                return BadRequest();
            }
            return NotFound();
        }
    }
}
