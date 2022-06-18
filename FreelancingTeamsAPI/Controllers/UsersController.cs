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
    public class UsersController : ControllerBase
    {
        private readonly IUser<User> user;

        public UsersController(IUser<User> _user)
        {
            user = _user;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var obj = await user.GetAll();
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }
        // GET: api/Users/Clients
        [HttpGet("Clients")]
        public async Task<ActionResult<IEnumerable<User>>> GetClients()
        {
            var obj = await user.GetClients();
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }
        // GET: api/Users/Freelancers
        [HttpGet("Freelancers")]
        public async Task<ActionResult<IEnumerable<User>>> GetFreelancers()
        {
            var obj = await user.GetFreelancers();
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var obj = await user.GetById(id);
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUser(User User)
        {
            if (User != null)
            {
                var obj = await user.Update(User);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {

            if (User != null)
            {
                var obj = await user.Create(User);
                if (obj != null)
                {
                    if(obj.Id == 0)
                    {
                        return Conflict();
                    }
                    return CreatedAtAction("GetUser", new { id = obj.Id }, obj);
                }
                return Problem("Entity set 'FreeLanceProjectContext.Users'  is null.");
            }
            return BadRequest();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id != 0)
            {
                var deleted = await user.Delete(id);
                if (deleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
    }
}
