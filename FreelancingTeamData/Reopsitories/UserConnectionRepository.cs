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
    public class UserConnectionRepository: IUserConnection<UserConnection>
    {
        private readonly FreeLanceProjectContext db;
        public UserConnectionRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public async Task<UserConnection> AddUserConnection(int UserId, string ConnectionId)
        {
            UserConnection userConnection = new UserConnection() { ConnectionId = ConnectionId, UserId = UserId };

            if (db.UserConnections == null)
            {
                return null;
            }
            db.UserConnections.Add(userConnection);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                    return null;
            }
            return userConnection;
        }
        public async Task<bool> DeleteUserConnection(string ConnectionId)
        {
            if (db.UserConnections == null)
            {
                return false;
            }
            var userConnection = await db.UserConnections.FirstOrDefaultAsync(a => a.ConnectionId == ConnectionId);
            if (userConnection == null)
            {
                return false;
            }

             db.UserConnections.Remove(userConnection);
            await db.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<string>> GetConnectionIds(int UserId)
        {
            var connectionIds = new List<string>();
            var connections = await db.UserConnections.Where(a => a.UserId == UserId).ToListAsync();
            foreach (var item in connections)
            {
                connectionIds.Add(item.ConnectionId);
            }
            return connectionIds;
        }
    }
}
