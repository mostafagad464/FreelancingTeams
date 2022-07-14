using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreelancingTeamData.Data;
using FreelancingTeamData.Models;
using FreelancingTeamData.Interfaces;

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeam<Team> TeamRepository;

        public TeamsController(ITeam<Team> _TeamRepository)
        {
            TeamRepository = _TeamRepository;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await TeamRepository.GetAll();
            if (teams == null)
            {
                return NotFound();
            }
            foreach (var team in teams)
            {
                team.Logo = null;
            }
            return Ok(teams);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await TeamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            team.Logo = null;
            return Ok(team);

        }

        //PUT: api/Teams/5
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }
            var EditedTeam = await TeamRepository.Update(team);
            if (EditedTeam == null)
            {
                return BadRequest();
            }
            EditedTeam.Logo = null;
            return Ok(EditedTeam);
        }

        //PUT: api/Teams/TeamMember
        [HttpPost("TeamMember")]
        public async Task<IActionResult> PostTeamMember(TeamMember teamMember)
        {
            var EditedTeam = await TeamRepository.AddTeamMember(teamMember);
            if (EditedTeam == null)
            {
                return BadRequest();
            }
            return Ok(EditedTeam);
        }

        //POST: api/Teams
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            if (team == null)
                return BadRequest();
            team.CreationDate = DateTime.Now;
            if (team.WalletId == 0)
                team.WalletId = null;

            var NewTeam = await TeamRepository.Create(team);
            if (NewTeam == null) //Not Added --> duplicate website 
                return BadRequest();
            else
                return Created("Success", NewTeam);
        }

        //DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var DeletedTeam = await TeamRepository.Delete(id);
            if (DeletedTeam == false)
                return NoContent();
            return Ok();
        }

        //private bool TeamExists(int id)
        //{
        //    return (_context.Teams?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
