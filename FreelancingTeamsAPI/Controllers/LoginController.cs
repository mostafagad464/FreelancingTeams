using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccount<Account> account;
        public LoginController(IAccount<Account> _account)
        {
            account = _account;
        }
        [HttpPost]
        public async Task<IActionResult> Login(usr usr)
        {
            if (usr.username != null && usr.password != null)
            {
                var Res = await account.Login(usr.username, usr.password);
                if (Res != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to my key"));

                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var data = new List<Claim>();
                    data.Add(new Claim("Id", Res.Id.ToString()));
                    data.Add(new Claim("Role", Res.Type));

                    var token = new JwtSecurityToken(
                    claims:data,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("/api/Logout")]
        public async Task<IActionResult> Logout(int Id)
        {
            if (Id != 0 )
            {
                await account.Logout(Id);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
    public class usr
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
