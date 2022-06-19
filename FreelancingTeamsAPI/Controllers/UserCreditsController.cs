using Microsoft.AspNetCore.Mvc;
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Interfaces;


namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreditsController : ControllerBase
    {

        private readonly  IUserCredit<UserCredit> _userCredit;
        public UserCreditsController(IUserCredit <UserCredit> userCredit)
        {
            _userCredit = userCredit;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCredit>>> GetAllUserCredits() 
        {
            var obj = await _userCredit.GetAll();

            if(obj != null)
            {
                return Ok(obj);
            }
            return BadRequest();
        }
        [HttpPost("addusercredit")]

        public async Task<ActionResult<UserCredit>> CreateUserCredit(UserCredit userCredit)
        {
            if(userCredit != null)
            {
                UserCredit newusercredit = await _userCredit.Create(userCredit);
                if(newusercredit != null)
                {
                    return Ok(newusercredit);
                }
                

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserCredit(int id, int creditNum)
        {
            if (id != 0)
            {

                bool usercredit = await _userCredit.Delete(id,creditNum);
                if (usercredit == true)
                {
                    return NoContent();
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCredit>> GetUserCredit(int id, int creditNum)
        {
            if (id != 0 && creditNum !=0)
            {
                var obj = await _userCredit.GetById(id,creditNum);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
        }

        

    }
}
