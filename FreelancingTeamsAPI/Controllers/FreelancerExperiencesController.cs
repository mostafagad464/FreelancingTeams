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
    public class FreelancerExperiencesController : ControllerBase
    {
        private readonly IExperience<FreelancerExperience> _experience;

        public FreelancerExperiencesController(IExperience<FreelancerExperience> experience)
        {
            _experience = experience;
        }

        // GET: api/FreelancerExperiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FreelancerExperience>>> GetFreelancerExperiences()
        {
            try
            {
                var obj =await _experience.GetAll();
                if(obj != null)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<FreelancerExperience>> GetFreelancerExperience(int id, DateTime? startDate)
        {
            if (id != 0 && startDate != null)
            {
                var obj = await _experience.GetById(id,startDate);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return NotFound();
        }

        // PUT: api/FreelancerExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelancerExperience(int id, DateTime startDate,FreelancerExperience freelancerExperience)
        {
            if(id == freelancerExperience.FreelancerId && startDate == freelancerExperience.StartDate)
            {
                var obj = await _experience.Update(id, startDate, freelancerExperience);
                if(obj != null)
                {
                    return Ok(obj);
                }
            }
            return BadRequest();
        }       
        // POST: api/FreelancerExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FreelancerExperience>> PostFreelancerExperience(FreelancerExperience freelancerExperience)
        {
            if(freelancerExperience != null)
            {
                var obj = await _experience.Create(freelancerExperience);
                if(obj != null)
                {
                    return Created("FreeLancerExperience", obj);
                }
            }
            return Problem("Can not create FreeLancerExperience");
        }

        // DELETE: api/FreelancerExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancerExperience(int id, DateTime? startDate)
        {
            if(id != 0 && startDate != null)
            {
                var obj = await _experience.GetById(id,startDate);
                if(obj != null)
                {
                    var obj1 = await _experience.Delete(id,startDate);
                    if(obj1 != null)
                    {
                    return Ok(obj);
                    }
                }
            }
            return BadRequest();
        }      
    }
}
