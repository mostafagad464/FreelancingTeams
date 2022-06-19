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
    public class ComplainsController : ControllerBase
    {
        private readonly IComplain<Complain> _complain;

        public ComplainsController(IComplain<Complain> complain)
        {
            _complain = complain;
        }

        // GET: api/Complains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complain>>> GetComplains()
        {
            var obj = await _complain.GetAll();
            if(obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }

        // GET: api/Complains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complain>> GetComplain(int id)
        {
            var obj = await _complain.GetById(id);
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
          
        }

        // PUT: api/Complains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplain(int id, Complain complain)
        {
            if(id != 0 && complain != null)
            {
                if (id != complain.Id)
                {
                    return BadRequest();
                }
                var obj = await _complain.Update(complain);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return BadRequest();  
        }

        // POST: api/Complains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Complain>> PostComplain(Complain complain)
        {
            if(complain != null)
            {
                var obj = await _complain.Create(complain);
                if (obj != null)
                {
                    return Created("Complain",obj);
                }
            }
            return Problem("Can not create complain");
        }

        // DELETE: api/Complains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplain(int id)
        {
            var obj = await _complain.GetById(id);
            if(obj != null)
            {
                var obj1 = await _complain.Delete(obj.Id);
                if(obj1 != null)
                {
                    return Ok(obj1);
                }
            }
            return BadRequest();          
        }
    }
}
