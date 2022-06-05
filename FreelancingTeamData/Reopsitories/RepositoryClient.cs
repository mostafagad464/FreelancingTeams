using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Reopsitories
{
    public class RepositoryClient : IClient<Client>
    {

        private readonly FreeLanceProjectContext db;

        public RepositoryClient(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public Task<Client> ChooseTeam(int TeamId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> PostProject(Client _object, IEnumerable<Client> _objects)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> SearchForTeamByName(string TeamName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> SearchForTeamBySkills(IEnumerable<Client> _objects)
        {
            throw new NotImplementedException();
        }
    }
}
