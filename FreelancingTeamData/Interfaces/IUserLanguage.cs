using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IUserLanguage<T>
    {
        public Task<T> Create(T _object);

        public Task<IEnumerable<T>> GetAll();

        public Task<bool> Delete(int userId, string language);

        public Task<T> GetById(int userId, string language);

    }
}
