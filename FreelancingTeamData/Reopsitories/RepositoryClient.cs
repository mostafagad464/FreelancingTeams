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
    public class RepositoryClient : IClient<Client>, ICRUD<Client>
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

        public Task<Client> Create(Client _object)
        {
            throw new NotImplementedException();
        }

        public Task<Client> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> EditProjectStatus(Client Oject)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> PayPayment(string _object)
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

        public Task<Client> Update(int id, Client _object)
        {
            throw new NotImplementedException();
        }
    }
}
