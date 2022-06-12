﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Data;
using FreelancingTeamData.Models;

namespace FreelancingTeamData.Reopsitories
{
    public class ClientRepository:IClient<Client>
    {
        FreeLanceProjectContext db = new FreeLanceProjectContext();
        public ClientRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public Task<Client> ChooseTeam(int TeamId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> CompleteProfile(Client _object)
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

        public Task<Client> Login(string mail, string password)
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

        public Task<Client> ShowNotifications(int AccountId, Client _object)
        {
            throw new NotImplementedException();
        }

        public Task<Client> Update(int id, Client _object)
        {
            throw new NotImplementedException();
        }
    }
}
