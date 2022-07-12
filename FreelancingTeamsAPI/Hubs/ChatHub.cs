using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;

namespace FreelancingTeamsAPI.Hubs
{
    public class ChatHub : Hub<IHubClient>
    {
        IUserConnection<UserConnection> _Repo;
        public ChatHub(IUserConnection<UserConnection> Repo)
        {
            _Repo = Repo;
        }
        public async override Task<Task> OnConnectedAsync()
        {
            var handler = new JwtSecurityTokenHandler();
            var access_token = Context.GetHttpContext().Request.Query["token"];
            if (!string.IsNullOrEmpty(access_token))
            {
                var tokenS = handler.ReadToken(access_token) as JwtSecurityToken;
                var id = tokenS.Claims.First(claim => claim.Type == "Id").Value;

                await _Repo.AddUserConnection(int.Parse(id), Context.ConnectionId);

            }
            return base.OnConnectedAsync();
        }
        public async override Task<Task> OnDisconnectedAsync(Exception? exception)
        {
            await _Repo.DeleteUserConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
