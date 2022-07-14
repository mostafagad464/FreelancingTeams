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
    public class FreelancerEducationsController : ControllerBase
    {
        private readonly IEducationSkill<FreelancerEducation> _education;

        public FreelancerEducationsController(IEducationSkill<FreelancerEducation> education)
        {
            _education = education;  
        }
        // GET: api/FreelancerEducations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FreelancerEducation>>> GetFreelancerEducations()
        {
            try
            {
                var obj = await _education.GetAll();
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

        // GET: api/FreelancerEducations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FreelancerEducation>> GetFreelancerEducation(int id, int gradY)
        {
            if (id != 0 && gradY != 0)
            {
                var obj = await _education.GetById(id, gradY);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return NotFound();
        }

        // PUT: api/FreelancerEducations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelancerEducation(int id, int gradY,FreelancerEducation freelancerEducation)
        {
            if (id == freelancerEducation.FreelancerId && gradY == freelancerEducation.gradYear)
            {
                var obj = await _education.Update(id, gradY, freelancerEducation);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return BadRequest();
        }

        // POST: api/FreelancerEducations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FreelancerEducation>> PostFreelancerEducation(FreelancerEducation freelancerEducation)
        {
            if (freelancerEducation != null)
            {
                var obj = await _education.Create(freelancerEducation);
                if (obj != null)
                {
                    return Created("FreeLancerEducation", obj);
                }
            }
            return Problem("Can not create FreeLancerEducation");
        }

        // DELETE: api/FreelancerEducations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancerEducation(int id, int gradY)
        {
            if (id != 0 && gradY != 0)
            {
                var obj = await _education.GetById(id, gradY);
                if (obj != null)
                {
                    var obj1 = await _education.Delete(id, gradY);
                    if (obj1 != null)
                    {
                        return Ok(obj);
                    }
                }
            }
            return BadRequest();          
        }
        [HttpGet("GetFreelancerEducation/{id}")]
        public async Task<ActionResult<IEnumerable<FreelancerSkill>>> GetFreelancerEducation(int id)
        {
            try
            {
                var obj = await _education.GetEducationById(id);

                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        //private bool FreelancerEducationExists(int id)
        //{
        //    return (_context.FreelancerEducations?.Any(e => e.FreelancerId == id)).GetValueOrDefault();
        //}
    }
}
