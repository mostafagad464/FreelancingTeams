using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Models;

namespace FreelancingTeamData.Interfaces
{
    public interface ITransaction<T1,T2>
    {
        //public Task<T> ProjectPayment(T _object, T _transaction);
        //public Task<T> ProjectPayment(T _object, int money, string method, DateTime dateTime);
        //public Task<T> TeamTransactions(T _object);

        public Task<T1> ProjectPayment(T1 _Transaction);
        public Task<T2> TransferredMoney(T2 _projectPayment);
        public Task<T2> RefundedMony(T2 _projectPayment);

        //public Task<ICollection<TeamTransaction>> TeamTransactions(List<TeamTransaction> _objects);
    }
}
