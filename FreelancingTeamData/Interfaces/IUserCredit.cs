using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IUserCredit<T>
    {

        public Task<T> Create(T _object);

        public Task<IEnumerable<T>> GetAll();

        public Task<bool> Delete(int userId, int creditNum);

        public Task<T> GetById(int userId, int creditNum);

    }
}
