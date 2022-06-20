using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface ICertificate<T>
    {
        public Task<T> Create(T _object);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> Update(int freelancerId, string title, T _object);                                               
                                                 
        public Task<T> GetById(int freelancerId, string title);  
                                               
        public Task<T> Delete(int freelancerId, string title);
    }
}
