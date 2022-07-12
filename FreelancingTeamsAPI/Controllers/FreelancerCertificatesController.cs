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
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerCertificatesController : ControllerBase
    {
        private readonly ICertificate<FreelancerCertificate> _certificate;

        public FreelancerCertificatesController(ICertificate<FreelancerCertificate> certificate)
        {
            _certificate = certificate;
        }

        // GET: api/FreelancerCertificates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FreelancerCertificate>>> GetFreelancerCertificates()
        {
            try
            {
                var obj = await _certificate.GetAll();
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

        // GET: api/FreelancerCertificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FreelancerCertificate>> GetFreelancerCertificate(int id, string title)
        {
            if (id != 0 && title != null)
            {
                var obj = await _certificate.GetById(id, title);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return NotFound();
        }

        // PUT: api/FreelancerCertificates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelancerCertificate(int id,  FreelancerCertificate freelancerCertificate)
        {
            if (id == freelancerCertificate.FreelancerId )
            {
                var obj = await _certificate.Update(id, freelancerCertificate.Title, freelancerCertificate);
                if (obj != null)
                {
                    return Ok(obj);
                }
            }
            return BadRequest();
        }

        // POST: api/FreelancerCertificates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FreelancerCertificate>> PostFreelancerCertificate(FreelancerCertificate freelancerCertificate)
        {
            if (freelancerCertificate != null)
            {
                var obj = await _certificate.Create(freelancerCertificate);
                if (obj != null)
                {
                    return Created("FreeLancerCertificate", obj);
                }
            }
            return Problem("Can not create FreeLancerCertificate");
        }

        // DELETE: api/FreelancerCertificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancerCertificate(int id, string title)
        {
            if (id != 0 && title != null)
            {
                var obj = await _certificate.GetById(id, title);
                if (obj != null)
                {
                    var obj1 = await _certificate.Delete(id, title);
                    if (obj1 != null)
                    {
                        return Ok(obj);
                    }
                }
            }
            return BadRequest();
        }
        [HttpGet("GetFreelancerCertificates/{id}")]
        public async Task<ActionResult<IEnumerable<FreelancerCertificate>>> GetAllFreelancerCertificatesByFreelancerId(int id)
        {
            try
            {
                var obj = await _certificate.GetAllFreelancerCertificates(id);

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

        //private bool FreelancerCertificateExists(int id)
        //{
        //    return (_context.FreelancerCertificates?.Any(e => e.FreelancerId == id)).GetValueOrDefault();
        //}
    }
}
