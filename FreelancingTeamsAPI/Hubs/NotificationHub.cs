using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace FreelancingTeamsAPI.Hubs
{
    public class NotificationHub : Hub<IHubClient>
    {
        IUserConnection<UserConnection> _Repo;
        IUser<User> _user;
        public NotificationHub(IUserConnection<UserConnection> Repo, IUser<User> user)
        {
            _Repo = Repo;
            _user = user;
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

                // Add User to team Group
                var user = await _user.GetById(int.Parse(id));
                if (user != null && user.Freelancer == true)
                {
                    foreach (var team in user.FreelancerNavigation.TeamMembers)
                    {
                        Console.WriteLine("******************************************");
                        Console.WriteLine("team" + team.TeamId);
                        Groups.AddToGroupAsync(Context.ConnectionId, "team" + team.TeamId);
                    }
                }
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
