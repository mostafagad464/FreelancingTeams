using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IEducationSkill<T>
    {
        public Task<T> Create(T _object);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> Update(int freelancerId, int id, T _object);


        public Task<T> GetById(int freelancerId, int id);

        public Task<T> Delete(int freelancerId, int id);
    }
}
