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
    public class WalletsController : ControllerBase
    {
        private IWallet<Wallet> walletProp;

        public WalletsController(IWallet<Wallet> _walletProp)
        {
            walletProp = _walletProp;
        }

        // GET: api/Wallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWallets()
        {
            var obj= await walletProp.GetAll();
            if(obj==null)
            {
                return BadRequest();

            }
            return Ok(obj);

        }

        // GET: api/Wallets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWallet(int id)
        {
            var obj= await walletProp.GetById(id);
            if(obj==null)
            {
                return NotFound();

            }
            return Ok(obj);
    
        }

        // PUT: api/Wallets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallet( Wallet wallet)
        {
           var obj= await walletProp.Update(wallet);
            if(obj!=null)
            {
                return Ok(obj);
            }
            return BadRequest();
            
        }

        // POST: api/Wallets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wallet>> PostWallet(Wallet wallet)
        {
            var newWalet = await walletProp.Create(wallet);
            if (newWalet == null)
            {
                return BadRequest();
            }
            return Created( "Success" , newWalet);

        }

        // DELETE: api/Wallets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            var obj = await walletProp.Delete(id);
            if (obj == false)
            {
                return NotFound();
            }
            return Ok(obj);
               
        }

        
    }
}
