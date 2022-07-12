using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IExperience<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> Create(T _object);

        public Task<T> Update(int id, DateTime? startDate, T _object);

        public Task<T> GetById(int id, DateTime? startDate);

        public Task<T> Delete(int id, DateTime? startDate);

        public Task<IEnumerable<T>> GetAllFreelancerExperiences(int Id);
    }
}
