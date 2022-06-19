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
    public class TeamTransactionsController : ControllerBase
    {
        private readonly ITeamTransactions<TeamTransaction> _teamTransactions;

        public TeamTransactionsController(ITeamTransactions<TeamTransaction> teamTransactions)
        {
            _teamTransactions = teamTransactions;
        }

        // GET: api/TeamTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamTransaction>>> GetTeamTransactions()
        {
            //TeamTransaction teamTransaction = new TeamTransaction();
            var teamTransactions = await _teamTransactions.GetAllTeamTransactions();
            if(teamTransactions != null)
            {
                return Ok(teamTransactions);
            }
            return BadRequest();
        }

        //get: api/teamtransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamTransaction>> getteamtransaction(int id)
        {
            TeamTransaction teamtransaction = await _teamTransactions.GetTeamTransactions(id);
            if (teamtransaction != null)
                return teamtransaction;
            return BadRequest();
            //if (db.teamtransactions == null)
            //{
            //    return notfound();
            //}
            //var teamtransaction = await db.teamtransactions.findasync(id);

            //if (teamtransaction == null)
            //{
            //    return notfound();
            //}

            //return teamtransaction;
        }

        //// PUT: api/TeamTransactions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTeamTransaction(List<TeamTransaction> teamTransaction)
        {
            if (teamTransaction == null)
                return BadRequest();
            List<TeamTransaction> teamTransactions1 = await _teamTransactions.EditTeamTransactions(teamTransaction);

            if (teamTransactions1 != null)
                return Ok(teamTransactions1);
            return NotFound();


            //db.Entry(teamTransaction).State = EntityState.Modified;

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TeamTransactionExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        //// POST: api/TeamTransactions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamTransaction>> PostTeamTransaction(List<TeamTransaction> teamTransactions)
        {
            if (teamTransactions == null)
                return BadRequest();
            List<TeamTransaction>  teamTransactions1 = await _teamTransactions.CreateTeamTransactions(teamTransactions);

            if (teamTransactions1 != null)
                return Ok(teamTransactions1);
            return BadRequest();
            
            //if (db.TeamTransactions == null)
            //{
            //    return Problem("Entity set 'FreeLanceProjectContext.TeamTransactions'  is null.");
            //}
            //db.TeamTransactions.Add(teamTransaction);
            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (TeamTransactionExists(teamTransaction.TeamId))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //    return CreatedAtAction("GetTeamTransaction", new { id = teamTransaction.TeamId }, teamTransaction);
            }

        // DELETE: api/TeamTransactions/5
        [HttpDelete]
        public async Task<IActionResult> DeleteTeamTransaction(List<TeamTransaction> teamTransactions)
        {
            if (teamTransactions != null)
            {
                var deleted = await _teamTransactions.DeleteTeamTransactions(teamTransactions);
                if (deleted == true)
                    return Ok(deleted);
                return NotFound();
            }
            return BadRequest();
        }

        //private bool TeamTransactionExists(int id)
        //{
        //    return (db.TeamTransactions?.Any(e => e.TeamId == id)).GetValueOrDefault();
        //}
    }
}
