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
    public class DealController : ControllerBase
    {
        private readonly IDeal<Deal> deal;

        public DealController(IDeal<Deal> _deal)
        {
            deal = _deal;
        }
        // DELETE: api/Deals/5
        [HttpDelete("{clientId}/{teamId}/{projectId}")]
        public async Task<IActionResult> DeleteDeal(int clientId , int teamId , int projectId)
        {
            var d = await deal.DeleteDeal(clientId , teamId , projectId);
            if (d == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<Deal>> PostDeal(Deal d)
        {
            Deal returnedDeal;

            try
            {
                returnedDeal = await deal.HireTeam(d);
            }
            catch
            {
                    return BadRequest();
            }
            
            return Created("created", returnedDeal);
        }

        /*       [HttpGet("{id}")]
               public async Task<ActionResult<Deal>> GetDeal(int id)
               {
                   var d = await db.Deals.FindAsync(id);

                   if (d == null)
                   {
                       return NotFound();
                   }

                   return d;
               }*/

        [HttpGet("{clientId}/{teamId}/{projectId}")]
        public async Task<IActionResult> getDeal(int clientId, int teamId, int projectId)
        {
            if (clientId ==null || teamId == null || projectId== null)
            {
                return BadRequest();
            }

            var returnedDeal = await deal.ProjectCompleted(clientId, teamId, projectId);

            if (returnedDeal == null)
                return Ok();

            //db.Entry(returnedDeal).State = EntityState.Modified;

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProjectDeal(int id, int teamId, int projectId)
        {
            if (id == null || teamId == null || projectId == null)
            {
                return BadRequest();
            }

            var returnedDeal = await deal.GetDeal(id, teamId, projectId);

            if (returnedDeal != null)
                return Ok(returnedDeal);

            //db.Entry(returnedDeal).State = EntityState.Modified;

            return NoContent();
        }

        [HttpPut("{clientId}/{teamId}/{projectId}")]
        public async Task<IActionResult> putDeal(int clientId, int teamId, int projectId , Deal d)
        {
            if (projectId != d.ProjectId || clientId != d.ClientId || teamId!= d.TeamId)
            {
                return BadRequest();
            }
            try
            {
              var returned = await deal.UpdateDeal(d);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!deal.DealExists(d.ClientId , d.TeamId , d.ProjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
    }
}
