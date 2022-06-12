using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Models;
using FreelancingTeamData.Data;


namespace FreelancingTeamData.Interfaces
{
    public interface IUser<T>:IAccount<T>
    {

        public abstract Task<T> CompleteProfile(T _object);

    }
}
