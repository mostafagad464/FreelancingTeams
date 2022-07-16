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
    public class NotificationsController : ControllerBase
    {
        private IHubContext<NotificationHub, IHubClient> _hubContext;
        INotification<Notification> _notification;
        IUserConnection<UserConnection> _userConnection;
        public NotificationsController(IHubContext<NotificationHub, IHubClient> hubContext, INotification<Notification> notification, IUserConnection<UserConnection> userConnection)
        {
            _hubContext = hubContext;
            _notification = notification;
            _userConnection = userConnection;
        }

        [HttpPost("account/{AccountId}")]
        public async Task<IActionResult> PostAccountNotification(int AccountId,Notification notification)
        {
            var retNoti = await _notification.AddAccountNotification(AccountId,notification);
            if (retNoti != null)
            {
                var Ids = await _userConnection.GetConnectionIds((int)retNoti.Accounts.FirstOrDefault().Id);
                foreach (var Id in Ids)
                {
                    _hubContext.Clients.Client(Id).Notify(retNoti);
                }
                return Ok(retNoti);
            }
            return Problem("Entity set 'FreeLanceProjectContext.AccountMessages'  is null.");
        }

        [HttpPost("team/{TeamId}")]
        public async Task<IActionResult> PostTeamNotification(int TeamId, Notification notification)
        {
            var retNoti = await _notification.AddTeamNotification(TeamId, notification);
            if (retNoti != null)
            {
                
                _hubContext.Clients.Group("team" + TeamId).Notify(retNoti);
                return Ok(retNoti);
            }
            return Problem("Entity set 'FreeLanceProjectContext.AccountMessages'  is null.");
        }

        [HttpGet("account/{Id}")]
        public async Task<ActionResult<IEnumerable<AccountMessage>>> GetAccountNotifications(int Id)
        {
            var Notifications = await _notification.GetAllAccNot(Id);
            if (Notifications == null)
            {
                return NotFound();
            }
            return Ok(Notifications);
        }

        [HttpGet("team/{Id}")]
        public async Task<ActionResult<IEnumerable<AccountMessage>>> GetTeamNotifications(int Id)
        {
            var Notifications = await _notification.GetAllTeamNot(Id);
            if (Notifications == null)
            {
                return NotFound();
            }
            return Ok(Notifications);
        }
    }
}
