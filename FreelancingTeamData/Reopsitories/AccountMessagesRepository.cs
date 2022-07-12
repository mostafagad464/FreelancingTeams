using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Reopsitories
{
    public class AccountMessagesRepository : IMessages<AccountMessage>
    {
        private readonly FreeLanceProjectContext db;
        public AccountMessagesRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public async Task<IEnumerable<AccountMessage>> GetChat(int SenderId, int ReceiverId)
        {
            if (db.AccountMessages == null)
            {
                return null;
            }
            var accountMessages = db.AccountMessages.Where(m => (m.SenderId == SenderId && m.RecieverId == ReceiverId) || (m.SenderId == ReceiverId && m.RecieverId == SenderId)).ToList();

            return accountMessages;
        }
        public async Task<IEnumerable<AccountMessage>> GetAllChats(int UserId, string? type)
        {
            if (db.AccountMessages == null)
            {
                return null;
            }
            var accountMessages = await db.AccountMessages.Where(m => m.SenderId == UserId || m.RecieverId == UserId).ToListAsync();

            return accountMessages;
        }
        public async Task<AccountMessage> SendMessage(AccountMessage accountMessage) //Add Message
        {
            try
            {
                if (db.AccountMessages == null)
                {
                    return null;
                }
                db.AccountMessages.Add(accountMessage);
                await db.SaveChangesAsync();

                return accountMessage;
            }
            catch (Exception)
            {

                return null;
            }
        }


    }
}
