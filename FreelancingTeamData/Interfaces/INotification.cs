using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface INotification<T>
    {
        public Task<T> AddAccountNotification(int AccountId, T notification);
        public Task<T> AddTeamNotification(int TeamId, T notification);
        public Task<IEnumerable<T>> GetAllAccNot(int AccountId);
        public Task<IEnumerable<T>> GetAllTeamNot(int TeamId);

    }
    
}
