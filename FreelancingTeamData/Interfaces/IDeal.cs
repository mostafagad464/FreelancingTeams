using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IDeal<T>
    {
        public Task<T> HireTeam(T _object);
        public Task<T> UpdateDeal(T _object);
        public Task<T> ProjectCompleted(int clientId, int TeamId, int projectId);
        public Task<T> GetDeal(int clientId, int TeamId, int projectId);
        public Task<T> DeleteDeal(int clientId, int TeamId, int projectId);
        public bool DealExists(int clientId, int TeamId, int projectId);
    }
}
