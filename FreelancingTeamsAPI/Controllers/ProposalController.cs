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
    public class ProposalController : ControllerBase
    {
        private readonly IProposal<Proposal> prop;

        public ProposalController(IProposal<Proposal> _prop)
        {
            prop = _prop;
        }
        [HttpPost]
        public async Task<ActionResult<Deal>> PostProposal(Proposal p)
        {
            Proposal returnedProposal;

            try
            {
                returnedProposal = await prop.Create(p);
            }
            catch
            {
                return BadRequest();
            }

            return Created("created", returnedProposal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProposal(int id)
        {
            var p = await prop.Delete(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetProposals()
        {
            var proposo = await prop.GetAll();
            Console.WriteLine("");
            return Ok(proposo);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proposal>> GetProposal(int id)
        {
            var p = await prop.GetById(id);

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putProposal(int id , Proposal p)
        {
            if (p.Id != id)
            {
                return BadRequest();
            }
            try
            {
                var returned = await prop.Update(p);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prop.ProposalExists(id))
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
