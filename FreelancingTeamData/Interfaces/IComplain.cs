using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    internal interface IComplain <T> : ICRUD<T>
    {
        public Task<T> Complain(T _object);
    }
}
