using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IAdmin <T>
    {
        public Task<T> HandleComplain(T _objeect);
        public Task<T> ValidateUserProfile(T _object);
        public Task<T> TransferPayment(T _object);
        public Task<T> RefoundPayment(T _object);
        public Task<T> DeliverPayment(T _object);
    }
}
