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
    public class FreelancerSkillsController : ControllerBase
    {
        private readonly IEducationSkill<FreelancerSkill> _skill;

        public FreelancerSkillsController(IEducationSkill<FreelancerSkill> skill)
        {
            _skill = skill;
        }

        // GET: api/FreelancerSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FreelancerSkill>>> GetFreelancerSkills()
        {
            try
            {
                var obj = await _skill.GetAll();
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

        // GET: api/FreelancerSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FreelancerSkill>> GetFreelancerSkill(int id, int skillId)
        {
            if (id != 0 && skillId != 0)
            {
                var obj = await _skill.GetById(id, skillId);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return NotFound();
        }

        // PUT: api/FreelancerSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelancerSkill(int id, int skillId, FreelancerSkill freelancerSkill)
        {
            if (id == freelancerSkill.FreelancerId && skillId == freelancerSkill.SkillId)
            {
                var obj = await _skill.Update(id, skillId, freelancerSkill);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return BadRequest();
        }

        // POST: api/FreelancerSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FreelancerSkill>> PostFreelancerSkill(FreelancerSkill freelancerSkill)
        {
            if (freelancerSkill != null)
            {
                var obj = await _skill.Create(freelancerSkill);
             
                if (obj != null)
                {
                    return Created("FreeLancerSkill", obj);
                }
            }
            return Problem("Can not create FreeLancerSkill");
        }

        // DELETE: api/FreelancerSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancerSkill(int id, int skillId)
        {
            if (id != 0 && skillId != 0)
            {
                var obj = await _skill.GetById(id, skillId);
                if (obj != null)
                {
                    var obj1 = await _skill.Delete(id, skillId);
                    if (obj1 != null)
                    {
                        return Ok(obj);
                    }
                }
            }
            return BadRequest();

            return NoContent();
        }
        [HttpGet("GetFreelancerSkills/{id}")]
        public async Task<ActionResult<IEnumerable<FreelancerSkill>>> GetFreelancerSkillsCategoriesById(int id)
        {
            try
            {
                var obj = await _skill.GetSkillCategoryNamesById(id);

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

        //private bool FreelancerSkillExists(int id)
        //{
        //    return (_context.FreelancerSkills?.Any(e => e.FreelancerId == id)).GetValueOrDefault();
        //}
    }
}
