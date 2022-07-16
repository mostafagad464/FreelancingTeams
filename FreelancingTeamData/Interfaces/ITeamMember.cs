using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface ITeamMember<T>
    {
        //public Task<IEnumerable<T>> GetAll();

        public Task<T> AddTeamMember(T _object);

        public Task<T> Update(int teamId, int freelancerId, T _object);

        public Task<IEnumerable<int>> GetTeamMembers(int teamId);

        public Task<bool> Delete(int teamId, int freelancerId);

        public Task<IEnumerable<T>> GetMembers(int teamId);

        public Task<T> GetFreelancer(T _object);
    }
}
