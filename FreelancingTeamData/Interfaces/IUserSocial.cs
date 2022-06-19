using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IUserSocial<T>
    {
        public Task<T> Create(T _object);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> Delete(int userId, string type);

        public Task<T> GetById(int userId, string type );

        public Task<T> Update(T _object);
    }
}
