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
    public class NotificationRepository : INotification<Notification>
    {
        private readonly FreeLanceProjectContext db;
        IAccount<Account> _account;
        ITeam<Team> _team;
        public NotificationRepository(FreeLanceProjectContext _db,IAccount<Account> account, ITeam<Team> team )
        {
            db = _db;
            _account = account;
            _team = team;
        }
        public async Task<Notification> AddAccountNotification(int AccountId, Notification notification) 
        {
            try
            {
                if (db.Notifications == null)
                {
                    return null;
                }
                var account = await _account.GetById(AccountId);
                notification.Accounts.Add(account);
                db.Notifications.AddAsync(notification);
                await db.SaveChangesAsync();
                return notification;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Notification> AddTeamNotification(int TeamId, Notification notification) 
        {
            try
            {
                if (db.Notifications == null)
                {
                    return null;
                }
                var team = await _team.GetById(TeamId);
                notification.Teams.Add(team);
                db.Notifications.AddAsync(notification);
                await db.SaveChangesAsync();
                return notification;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Notification>> GetAllAccNot(int AccountId)
        {
            if (db.Notifications == null)
            {
                return null;
            }
            var accountNotifications = await db.Notifications.Where(m => m.Accounts.Count > 0  && m.Accounts.First().Id == AccountId).ToListAsync();

            return accountNotifications;
        }

        public async Task<IEnumerable<Notification>> GetAllTeamNot(int TeamId)
        {
            if (db.Notifications == null)
            {
                return null;
            }
            var teamNotifications = await db.Notifications.Where(m => m.Teams.Count > 0 && m.Teams.First().Id == TeamId).ToListAsync();

            return teamNotifications;
        }
    }
}
