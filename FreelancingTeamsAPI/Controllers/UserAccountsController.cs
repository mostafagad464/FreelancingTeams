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
    public class UserAccountsController : ControllerBase
    {

        //private readonly FreeLanceProjectContext _context;
        private readonly ICRUD<UserAccount> crud;
        private readonly IPerson<UserAccount> person;

        public UserAccountsController(ICRUD<UserAccount> _crud, IPerson<UserAccount> _person)
        {
            crud = _crud;
            person = _person;
        }

        // GET: api/UserAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccount>>> GetUserAccounts()
        {
            //var obj = await crud.GetAll();
            var obj = await crud.GetAll();
            if (obj != null)
            //if (_context.UserAccounts == null)
            {
                //return NotFound();
                return Ok(obj);
            }
            return NotFound();
        }
        
        // GET: api/UserAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccount>> GetUserAccount(int id)
        {

            //if (_context.UserAccounts == null)
            //{
            //    return NotFound();
            //}
            if (id!=0)
            {
                var obj = await crud.GetById(id);
                if(obj!=null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
            //var userAccount = await _context.UserAccounts.FindAsync(id);

            //if (userAccount == null)
            //{
            //    return NotFound();
            //}
            //return userAccount;
        }

        // PUT: api/UserAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccount(int id, UserAccount userAccount)
        {

            if (id != 0 && userAccount != null)
            {
                var obj = await crud.Update(id, userAccount);
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

            //if (id != userAccount.Id)
            //{
            //    return BadRequest();
            //}

            ////_context.Entry(userAccount).State = EntityState.Modified;

            //try
            //{
            //    var obj = await crud.Update(id, userAccount);
            //    //await _context.SaveChangesAsync();
            //    if (obj != null)
            //    {
            //        return Ok(obj);
            //    }
            //    else NotFound();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    //if (!UserAccountExists(id))
            //    //{
            //        return BadRequest();
            //    //}
            //    //else
            //    //{
            //    //    throw;
            //    //}
            //}

        }

        // POST: api/UserAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccount(UserAccount userAccount)
        {
            if (User!=null)
            {
                var obj = await crud.Create(userAccount);
                if (obj != null)
                {
                    string url = HttpContext.Request.Path.Value;
                    return Created(url, obj);
                }
            }
            return Problem("Entity set 'FreeLanceProjectContext.UserAccounts'  is null.");

            //_context.UserAccounts.Add(userAccount);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserAccount", new { id = userAccount.Id }, userAccount);
        }

        // DELETE: api/UserAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount(int id)
        {
            if (id != 0)
            {
                //return NotFound();

                var userAccount = await crud.Delete(id);
                if (userAccount != null)
                {
                    return Ok(userAccount);
                }
                else
                {
                    return NoContent();

                }
                //_context.UserAccounts.Remove(userAccount);
                //await _context.SaveChangesAsync();

            }
            return BadRequest();
        }

        //private bool UserAccountExists(int id)
        //{
        //    return (_context.UserAccounts?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        
    }
}
