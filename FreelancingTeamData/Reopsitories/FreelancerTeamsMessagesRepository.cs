using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Reopsitories
{
    public class FreelancerTeamsMessagesRepository : IMessages<TeamFreelancerMessage>
    {
        private readonly FreeLanceProjectContext db;
        public FreelancerTeamsMessagesRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public async Task<IEnumerable<TeamFreelancerMessage>> GetAllChats(int Id, string type)
        {
            if (db.AccountMessages == null)
            {
                return null;
            }
            List<TeamFreelancerMessage> messages = new List<TeamFreelancerMessage>();
            if (type == "team")
            {
                messages = db.TeamFreelancerMessages.Where(m => m.TeamId == Id).ToList();
            }
            else if(type == "user")
            {
                messages = db.TeamFreelancerMessages.Where(m => m.UserId == Id).ToList();
            }

            return messages;
        }

        public async Task<IEnumerable<TeamFreelancerMessage>> GetChat(int TeamId, int UserId)
        {
            if (db.TeamFreelancerMessages == null)
            {
                return null;
            }
            var messages = db.TeamFreelancerMessages.Where(m => m.TeamId == TeamId && m.UserId == UserId).ToList();

            return messages;
        }

        public async Task<TeamFreelancerMessage> SendMessage(TeamFreelancerMessage teamFreelancerMessage)
        {
            try
            {
                if (db.TeamFreelancerMessages == null)
                {
                    return null;
                }
                db.TeamFreelancerMessages.Add(teamFreelancerMessage);
                await db.SaveChangesAsync();

                return teamFreelancerMessage;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
