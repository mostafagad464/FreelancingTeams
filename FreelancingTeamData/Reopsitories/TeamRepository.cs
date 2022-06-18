using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Data;
using FreelancingTeamData.Models;


namespace FreelancingTeamData.Reopsitories
{
    internal class TeamRepository:ITeam<Team>
    {
        FreeLanceProjectContext db = new FreeLanceProjectContext();

        public TeamRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public Task<Team> Create(Team _object)
        {
            throw new NotImplementedException();
        }

        public Task<Team> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetNotifications(int TeamID, Team _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task<Team>> GetTeamMemebers(int TeamID)
        {
            throw new NotImplementedException();
        }

        public Task<Team> OfferProposal(Team _object)
        {
            throw new NotImplementedException();
        }

        public Task<Team> SerchForProject(IEnumerable<Team> _objects)
        {
            throw new NotImplementedException();
        }

        public Task<Team> SubmitProject(Team _object)
        {
            throw new NotImplementedException();
        }

        public Task<Team> Update(Team _object)
        {
            throw new NotImplementedException();
        }
    }
}
