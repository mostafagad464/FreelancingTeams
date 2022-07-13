using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IPortoflio<T> : ICRUD<T>
    {        public Task<IEnumerable<T>> GetFreelancerPortfolio(int id);

    }
}
