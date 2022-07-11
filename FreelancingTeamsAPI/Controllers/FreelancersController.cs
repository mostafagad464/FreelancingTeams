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
    public class FreelancersController : ControllerBase
    {
        private readonly IFreelancer<Freelancer> _freelancer;

        public FreelancersController(IFreelancer<Freelancer> freelancer)
        {
            _freelancer = freelancer;
        }
        // GET: api/Freelancers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Freelancer>>> GetFreelancers()
        {
            try
            {
                var obj = await _freelancer.GetAll();
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: api/Freelancers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Freelancer>> GetFreelancer(int id)
        {
            if (id != 0)
            {
                var obj = await _freelancer.GetById(id);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return NotFound();
        }

        // PUT: api/Freelancers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelancer(int id, Freelancer freelancer)
        {
            if (id == freelancer.Id)
            {
                var obj = await _freelancer.Update(freelancer);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return BadRequest();
        }

        // POST: api/Freelancers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Freelancer>> PostFreelancer(Freelancer freelancer)
        {
            if (freelancer != null)
            {
                var obj = await _freelancer.Create(freelancer);
                if (obj != null)
                {
                    return Created("FreeLancer", obj);
                }
            }
            return Problem("Can not create FreeLancer");
        }

        // DELETE: api/Freelancers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer(int id)
        {
            if (id != 0)
            {
                var obj = await _freelancer.GetById(id);
                if (obj != null)
                {
                    var obj1 = await _freelancer.Delete(id);
                    if (obj1 != null)
                    {
                        return Ok(obj);
                    }
                }
            }
            return BadRequest();
        }

        //private bool FreelancerExists(int id)
        //{
        //    return (_context.Freelancers?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
