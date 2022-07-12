using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IUserConnection<T>
    {
        public Task<T> AddUserConnection(int UserId, string ConnectionId);
        public Task<bool> DeleteUserConnection(string ConnectionId);
        public Task<IEnumerable<string>> GetConnectionIds(int UserId);

    }
}
