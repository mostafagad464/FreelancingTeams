using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IAccount<T>
    {
        public Task<T> Login(string mail, string password);
        //public Boolean Register(T _object);

        // Admin can Check project completion and the client
        // No implementation in user or make interface for it
        //public Task<T> CheckProjectCompletion(T _object);
        



        public Task<T> ShowNotifications(int AccountId, T _object);




    }
}
