using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Reopsitories
{
    public class ClientRepository : IClient<Client>
    {
        private readonly FreeLanceProjectContext db;

        public ClientRepository(FreeLanceProjectContext _db)
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

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> EditProjectStatus(Client Oject)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Client>> GetAll()
        {
            try
            {
                return await db.Clients.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<Client> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetClients()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetFreelancers()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetImage(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> PayPayment(string _object)
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

        public Task<byte[]> SetImage(int UserId, IFormFile image)
        {
            throw new NotImplementedException();
        }

        public Task<Client> Update(Client _object)
        {
            throw new NotImplementedException();
        }
    }
}
