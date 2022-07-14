using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using FreelancingTeamsAPI.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub, IHubClient> _hubContext;
        IMessages<AccountMessage> _accountMessage;
        IMessages<TeamFreelancerMessage> _teamFreelancerMessage;
        IUserConnection<UserConnection> _userConnection;
        public ChatController(IHubContext<ChatHub, IHubClient> hubContext, IMessages<AccountMessage> accountMessage, IMessages<TeamFreelancerMessage> teamFreelancerMessage, IUserConnection<UserConnection> userConnection)
        {
            _hubContext = hubContext;
            _accountMessage = accountMessage;
            _teamFreelancerMessage = teamFreelancerMessage;
            _userConnection = userConnection;
        }

        [HttpPost("account")]
        public async Task<IActionResult> Post(AccountMessage message)
        {
            var retMessage = await _accountMessage.SendMessage(message);
            if (retMessage != null)
            {
                var Ids = await _userConnection.GetConnectionIds((int)retMessage.RecieverId);
                foreach (var Id in Ids)
                {
                    _hubContext.Clients.Client(Id).AccountsMessaging(message);
                }
                //_hubContext.Clients.All.AccountsMessaging(message);
                return Ok(retMessage);
            }
            return Problem("Entity set 'FreeLanceProjectContext.AccountMessages'  is null.");
        }

        [HttpPost("team")]
        public async Task<IActionResult> Post(TeamFreelancerMessage message)
        {
            var retMessage = await _teamFreelancerMessage.SendMessage(message);
            if (retMessage != null)
            {
                if(retMessage.Sender == "T" || retMessage.Sender == "t")
                {
                    var Ids = await _userConnection.GetConnectionIds((int)retMessage.UserId);
                    foreach (var Id in Ids)
                    {
                        _hubContext.Clients.Client(Id).TeamsAndFreelancersMesseging(retMessage);
                    }
                }
                else if(retMessage.Sender == "U" || retMessage.Sender == "u")
                {
                    _hubContext.Clients.Group("team" + retMessage.TeamId).TeamsAndFreelancersMesseging(retMessage);
                }
                else
                {
                    return BadRequest();
                }
                //_hubContext.Clients.All.TeamsAndFreelancersMesseging(message);
                return Ok(retMessage);
            }
            return Problem("Entity set 'FreeLanceProjectContext.AccountMessages'  is null.");
        }

        [HttpGet("account/chat")]
        public async Task<ActionResult<IEnumerable<AccountMessage>>> GetChat(int SenderId,int RecieverId)
        {
            var Chat = await _accountMessage.GetChat(SenderId, RecieverId);
            if(Chat == null)
            {
                return NotFound();
            }
            return Ok(Chat);
        }
        [HttpGet("team/chat")]
        public async Task<ActionResult<IEnumerable<TeamFreelancerMessage>>> GetTeamChat(int TeamId, int UserId)
        {
            var Chat = await _teamFreelancerMessage.GetChat(TeamId,UserId);
            if (Chat == null)
            {
                return NotFound();
            }
            return Ok(Chat);
        }
        [HttpGet("account")]
        public async Task<ActionResult<IEnumerable<AccountMessage>>> GetAll(int UserId)
        {
            var Chats = await _accountMessage.GetAllChats(UserId, null);
            if (Chats == null)
            {
                return NotFound();
            }
            return Ok(Chats);
        }
        [HttpGet("team")]
        public async Task<ActionResult<IEnumerable<TeamFreelancerMessage>>> GetAll(int UserId,string type)
        {
            if (type != "user" && type != "team")
            {
                return BadRequest();
            }
            var Chats = await _teamFreelancerMessage.GetAllChats(UserId, type);
            if (Chats == null)
            {
                return NotFound();
            }
            return Ok(Chats);

        }

        [HttpPut("account")]
        public async Task<ActionResult<IEnumerable<AccountMessage>>> SetChatRead(int SenderId, int RecieverId)
        {
            var newChat = await _accountMessage.SetChatRead(SenderId, RecieverId,null);
            if (newChat == null)
            {
                return NotFound();
            }
            return Ok(newChat);
        }

        [HttpPut("team")]
        public async Task<ActionResult<IEnumerable<AccountMessage>>> SetTeamChatRead(int TeamId, int UserId, string Sender)
        {
            var newChat = await _teamFreelancerMessage.SetChatRead(TeamId, UserId, Sender);
            if (newChat == null)
            {
                return NotFound();
            }
            return Ok(newChat);
        }
    }
}
