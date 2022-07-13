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
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly ITeamMember<TeamMember> _member;

        public TeamMembersController(ITeamMember<TeamMember> member)
        {
            _member = member;
        }

        // GET: api/TeamMembers
        //[HttpGet]
        [HttpGet("{id}")]

        public async Task<ActionResult<List<int>>> GetTeamMembers(int id)
        {
            if (id != 0)
            {
                var obj = await _member.GetTeamMembers(id);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return NotFound();
        }



        // GET: api/TeamMembers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
        //{
        //  if (_context.TeamMembers == null)
        //  {
        //      return NotFound();
        //  }
        //    var teamMember = await _context.TeamMembers.FindAsync(id);

        //    if (teamMember == null)
        //    {
        //        return NotFound();
        //    }

        //    return teamMember;
        //}

        // PUT: api/TeamMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTeamMember(int id, TeamMember teamMember)
        //{
            
        //}

        // POST: api/TeamMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teamMember)
        {
            if (teamMember != null)
            {
                var obj = await _member.AddTeamMember(teamMember);
                if (obj != null)
                {
                    return Created("teamMember", obj);
                }
            }
            return Problem("teamMember");
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id, int freelancerId)
        {
            if (id != 0 && freelancerId != 0)
            {
                var obj = await _member.GetTeamMembers(id);
                if (obj != null)
                {
                    var obj1 = await _member.Delete(id, freelancerId);
                    if (obj1 != null)
                    {
                        return Ok(obj);
                    }
                }
            }
            return BadRequest();
        }

        //private bool TeamMemberExists(int id)
        //{
        //    return (_context.TeamMembers?.Any(e => e.TeamId == id)).GetValueOrDefault();
        //}
    }
}
