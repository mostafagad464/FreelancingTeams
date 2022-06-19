using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface ITeamTransactions<T>
    {
        public Task<List<T>> CreateTeamTransactions(List<T> _objects);
        public Task<List<T>> EditTeamTransactions(List<T> _objects);
        public Task<bool> DeleteTeamTransactions(List<T> _objects);
        public Task<List<T>> GetAllTeamTransactions();
        public Task<T> GetTeamTransactions(int id);
        //Task<List<TeamTransaction>> EditTeamTransactions(TeamTransaction teamTransaction);
    }
}
