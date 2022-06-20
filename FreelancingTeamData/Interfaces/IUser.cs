using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Models;
using FreelancingTeamData.Data;


namespace FreelancingTeamData.Interfaces
{
    public interface IUser<T> : ICRUD<T>
    {
        public abstract Task<IEnumerable<T>> GetFreelancers();
        public abstract Task<IEnumerable<T>> GetClients();

    }
}
