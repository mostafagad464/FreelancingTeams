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
    public class PortoflioController : ControllerBase
    {
        IPortoflio<Portoflio> portof;
       public PortoflioController(IPortoflio<Portoflio> _portof)
        {
            portof= _portof;

        }

        // GET: api/Portoflio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portoflio>>> GetPortoflios()
        {
            IEnumerable< Portoflio > portofs = await portof.GetAll();
            
            if(portofs==null)
            {
                return BadRequest();

            }
            return Ok(portofs);


        }
        // GET: api/Portoflio/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Portoflio>> GetPortoflio(int id)
        //{
        //    var reqPortof = await portof.GetById(id);
        //    if (reqPortof == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(reqPortof);


        //}

        //// POST: api/Portoflio
        [HttpPost]
        public async Task<ActionResult<Portoflio>> PostPortoflio(Portoflio portoflio)
        {
            portof.Create(portoflio);

            if(portoflio==null)
            {
                return BadRequest();

            }
            return Ok(portoflio);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePortoflio(int id)
        {
            var vlaue=await portof.Delete(id);
            if (vlaue == false)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<Portoflio>> PutPortoflio(int id, Portoflio portoflio)
        {
            var updatedPorto = await portof.Update( portoflio);
            if(updatedPorto==null)
            {
                return BadRequest();
            }
            return Ok(updatedPorto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Portoflio>>> GetFreelancerPortoflios(int id)
        {
            IEnumerable<Portoflio> portfolios = await portof.GetFreelancerPortfolio(id);

            if (portfolios == null)
            {
                return BadRequest();

            }
            return Ok(portfolios);


        }

    }
}
