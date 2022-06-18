using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface ICRUD <T>
    {
        public Task<T> Create(T _object);

        public Task<T> Update( T _object);

        public Task<T> Delete(int id);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int id);
    }
}
