using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var Res = await account.Login(username, password);
                if (Res != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to my key"));

                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
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
    }

}
