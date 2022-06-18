using Microsoft.AspNetCore.Mvc;
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Interfaces;


namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialsController : ControllerBase
    {

        private readonly IUserSocial<UserSocial> _userSocial;
        public UserSocialsController(IUserSocial<UserSocial> userSocial)
        {
            _userSocial = userSocial;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSocial>>> GetAllUserSocials()
        {
            var obj = await _userSocial.GetAll();

            if (obj != null)
            {
                return Ok(obj);
            }
            return BadRequest();
        }
        [HttpPost("addusersocial")]

        public async Task<ActionResult<UserSocial>> CreateUserSocial(UserSocial userSocial)
        {
            if (userSocial != null)
            {
                UserSocial newusersocial = await _userSocial.Create(userSocial);
                if (newusersocial != null)
                {
                    return Ok(newusersocial);
                }


            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserSocial(int id, string type)
        {
            if (id != 0 && type!="" )
            {

                var usersocial = await _userSocial.Delete(id, type );
                if (usersocial != null)
                {
                    return Ok(usersocial);
                }
                else
                {
                    return NoContent();

                }


            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserSocial>> GetUserSocial(int id, string type)
        {
            if (id != 0 && type != "")
            {
                var obj = await _userSocial.GetById(id, type);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserSocial(UserSocial userSocial)
        {

            if (userSocial != null)
            {
                var obj = await _userSocial.Update(userSocial);
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
