using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IHubClient
    {
        Task AccountsMessaging(AccountMessage message);
        Task TeamsAndFreelancersMesseging(TeamFreelancerMessage message);
        Task Notify(Notification not);

    }
}
