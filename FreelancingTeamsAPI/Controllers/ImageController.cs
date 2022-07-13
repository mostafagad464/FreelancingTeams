using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IUser<User> user;
        ITeam<Team> team;
        public ImageController(IUser<User> _user, ITeam<Team> _team)
        {
            user = _user;
            team = _team;
        }
        [HttpPost("{UserId}")]
        public async Task<IActionResult> Post(int UserId, [FromForm] FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.files.Length > 0)
                {
                    var image = await user.SetImage(UserId,fileUpload.files);
                    string path = "https://localhost:7152/api/Image?UserId=" + UserId.ToString();
                    return Ok(new { image = path });
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get(int UserId)
        {
            var image = await user.GetImage(UserId);
            if(image == null)
            {
                return NotFound();
            }
            return File(image, "image/jpg");
        }

        [HttpPost("Team/{TeamId}")]
        public async Task<IActionResult> PostTeamImg(int TeamId, [FromForm] FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.files.Length > 0)
                {
                    var image = await team.SetImage(TeamId, fileUpload.files);
                    string path = "https://localhost:7152/api/Image/Team?TeamId=" + TeamId.ToString();
                    return Ok(new { image = path });
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Team")]
        public async Task<IActionResult> GetTeamImg(int TeamId)
        {
            var image = await team.GetImage(TeamId);
            if (image == null)
            {
                return NotFound();
            }
            return File(image, "image/jpg");
        }
    }

    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
