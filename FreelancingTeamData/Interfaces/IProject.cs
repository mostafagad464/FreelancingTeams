using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IProject<T>
    {
        public Task<T> Deal(T Oject);
        public Task<T> CheckProjectCompletion(T Oject);
        public Task<T> Review(T Oject);
        public Task<T> CancelProject(T Oject);

        

    }
}
