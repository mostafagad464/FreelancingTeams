using Microsoft.AspNetCore.Mvc;
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Interfaces;



namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLanguagesController : ControllerBase
    {
        private readonly IUserLanguage<UserLanguage> _userLanguage;
        public UserLanguagesController(IUserLanguage<UserLanguage> userLanguage)
        {
            _userLanguage = userLanguage;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLanguage>>> GetAllUserLanguages()
        {
            var obj = await _userLanguage.GetAll();

            if (obj != null)
            {
                return Ok(obj);
            }
            return BadRequest();
        }
        [HttpPost("adduserlanguage")]

        public async Task<ActionResult<UserLanguage>> CreateUserLanguage(UserLanguage userLanguage)
        {
            if (userLanguage != null)
            {
                UserLanguage newuserlanguage = await _userLanguage.Create(userLanguage);
                if (newuserlanguage != null)
                {
                    return Ok(newuserlanguage);
                }


            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserLanguage(int id, string userLanguage)
        {
            if (id != 0 && userLanguage != "")
            {

                var userlanguage = await _userLanguage.Delete(id, userLanguage);
                if (userlanguage != null)
                {
                    return Ok(userlanguage);
                }
                else
                {
                    return NoContent();

                }


            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCredit>> GetUserLanguage(int id, string userLanguage)
        {
            if (id != 0 && userLanguage != "")
            {
                var obj = await _userLanguage.GetById(id, userLanguage);
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
