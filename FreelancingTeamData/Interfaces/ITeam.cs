using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface ITeam <T>
    {

        public Task<T> SubmitProject(T _object);
        public Task<T> SerchForProject(IEnumerable<T> _objects);
        //public Task<T> CancelProject(T _object);
        public Task<T> OfferProposal(T _object);
        //public Task<T> Review(T Oject);
        public Task<T> GetNotifications(int TeamID, T _object);
        //public Task<T> Communicate(T _object);
        //public Task<T> Deal(T _object);
        public IEnumerable<Task<T>> GetTeamMemebers(int TeamID);


        






    }
}
