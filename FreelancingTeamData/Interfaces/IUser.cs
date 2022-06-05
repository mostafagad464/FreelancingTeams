using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IUser<T>
    {
        public void CompleteProfile(int UserId, Task _object);
        public void MakeComplains(int Id, int UserId, int ProjectId);
        
        //public Task<T> DealWithTeam(T _object);

        //public Task<T> CancelProject(int ProjectId);

        //public Task<IEnumerable<T>> Communication(T _object, int TeamId);





    }
}
