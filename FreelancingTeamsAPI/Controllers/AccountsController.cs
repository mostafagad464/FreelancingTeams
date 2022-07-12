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
    public class AccountsController : ControllerBase
    {

        private readonly IAccount<Account> account;

        public AccountsController( IAccount<Account> _account)
        {
            account = _account;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var obj = await account.GetAll();
            if (obj != null)
            {
                foreach (var account in obj)
                {
                    account.Password = null;
                }
                return Ok(obj);
            }
            return NotFound();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var obj = await account.GetById(id);
            if (obj != null)
            {
                obj.Password = null;
                return Ok(obj);
            }
            return NotFound();
        }

        // GET: api/Accounts/Admins
        [HttpGet("Admins")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAdmins()
        {
            var obj = await account.GetAdmins();
            if (obj != null)
            {
                foreach (var admin in obj)
                {
                    admin.Password = null;
                }
                return Ok(obj);
            }
            return NotFound();
        }

        // GET: api/Accounts/UserName
        [HttpGet("UserName")]
        public async Task<ActionResult<Account>> GetUserName(string First_Name, string Last_Name)
        {
            if(!String.IsNullOrEmpty(First_Name) && !String.IsNullOrEmpty(Last_Name))
            {
                string UserName = await account.UniqueUserName(First_Name,Last_Name);
                return Ok(new { UserName = UserName });

            }
            return BadRequest();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account Account)
        {
            if (Account != null)
            {
                var obj = await account.Create(Account);
                if (obj != null)
                {
                    //string url = HttpContext.Request.Path.Value;
                    //return Created(url, obj);
                    if (obj.Id == 0)
                    {
                        return Conflict();
                    }
                    obj.Password = null;
                    return CreatedAtAction("GetAccount", new { id = obj.Id }, obj);
                }
                return Problem("Entity set 'FreelancingTeamsContext.Account'  is null.");
            }
            return BadRequest();
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAccount(Account Account)
        {
            if (Account != null)
            {
                var obj = await account.Update(Account);
                if (obj != null)
                {
                    obj.Password = null;
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
        }


        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            if (id != 0)
            {
                var deleted = await account.Delete(id);
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
