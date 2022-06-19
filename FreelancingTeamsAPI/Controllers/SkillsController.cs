using Microsoft.AspNetCore.Mvc;
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Interfaces;
namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkill<Skill> _skill;
        public SkillsController(ISkill<Skill> skill)
        {

            _skill = skill;
        }


        [HttpPost("addskill")]
        public async Task<ActionResult<Category>> CreateSkill(Skill skill)
        {
            if (skill != null)
            {
                Skill newSkill = await _skill.Create(skill);
                if (newSkill != null)
                    return Ok(newSkill);
            }
            return BadRequest();
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {

            var obj = await _skill.GetAll();

            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkill(int id)
        {
            if (id != 0)
            {

                var skill = await _skill.Delete(id);
                if (skill != null)
                {
                    return Ok(skill);
                }
                else
                {
                    return NoContent();

                }


            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            if (id != 0)
            {
                var obj = await _skill.GetById(id);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            if ( skill != null)
            {
                var obj = await _skill.Update(skill);
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
        }
    }
}
