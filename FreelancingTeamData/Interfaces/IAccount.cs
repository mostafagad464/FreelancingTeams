using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IAccount<T>:ICRUD<T>
    {
        public Task<T> Login(string mail, string password);
        public Task<IEnumerable<T>> GetAdmins();

    }
}
