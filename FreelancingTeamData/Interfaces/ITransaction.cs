using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Models;

namespace FreelancingTeamData.Interfaces
{
    public interface ITransaction<T>
    {
        //public Task<T> ProjectPayment(T _object, T _transaction);
        //public Task<T> ProjectPayment(T _object, int money, string method, DateTime dateTime);
        public Task<T> ProjectPayment(T _object, int clientId, int projectId);
        //public Task<T> TeamTransactions(T _object);
        public Task<ICollection<TeamTransaction>> TeamTransactions(List<TeamTransaction> _objects);
    }
}
