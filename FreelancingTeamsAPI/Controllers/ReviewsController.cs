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
    public class ReviewsController : ControllerBase
    {
        private readonly IReview<Review> review;

        public ReviewsController(IReview<Review> _review)
        {
            review = _review;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var obj = await review.GetAll();
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }

        // GET: api/Reviews/5
        [HttpGet("{ClientId}/{TeamId}/{ProjectId}")]
        public async Task<ActionResult<Review>> GetReview(int ClientId, int TeamId, int ProjectId)
        {
            var obj = await review.GetById(ClientId,TeamId,ProjectId);
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutReview(Review Review)
        {
            if (Review != null)
            {
                var obj = await review.Update(Review);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
        }

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review Review)
        {
            if (Review != null)
            {
                var obj = await review.Create(Review);
                if (obj != null)
                {
                    if (obj.Rate == -1)
                    {
                        return Conflict();
                    }
                    return CreatedAtAction("GetReview", new { ClientId = obj.ClientId, TeamId = obj.TeamId, ProjectId = obj.ProjectId }, obj);
                }
                return Problem("Entity set 'FreeLanceProjectContext.Users'  is null.");
            }
            return BadRequest();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{ClientId}/{TeamId}/{ProjectId}")]
        public async Task<IActionResult> DeleteReview(int ClientId, int TeamId, int ProjectId)
        {
            if (ClientId != 0 && TeamId!=0 && ProjectId!=0)
            {
                var deleted = await review.Delete(ClientId, TeamId, ProjectId);
                if (deleted)
                {
                    return NoContent();
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
