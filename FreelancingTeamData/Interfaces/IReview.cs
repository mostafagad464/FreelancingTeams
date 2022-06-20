using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IReview<T>
    {
        public Task<T> Create(T _object);

        public Task<T> Update(T _object);

        public Task<bool> Delete(int CId, int TId,int PId);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int CId, int TId, int PId);
    }
}
