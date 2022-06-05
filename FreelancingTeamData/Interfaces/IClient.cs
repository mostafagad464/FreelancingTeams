using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IClient<T>
    {
        public Task<T> ChooseTeam(int TeamId);
        
        // One Project With more than onee skill
        public Task<T> PostProject(T _object, IEnumerable<T> _objects);
        
        // More than one skill
        public Task<IEnumerable<T>> SearchForTeamBySkills(IEnumerable<T> _objects);

        public Task<IEnumerable<T>> SearchForTeamByName(string TeamName);


        //public Task<T> PayForProject()
        public Task<T> PayPayment(string _object);
        public Task<T> EditProjectStatus(T Oject);
        //public Task<T> Review(T Oject);


    }
}
