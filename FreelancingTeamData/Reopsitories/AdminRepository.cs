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
    internal class AdminRepository: IAdmin<Admin>
    {
        FreeLanceProjectContext db = new FreeLanceProjectContext();

        public AdminRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public Task<Admin> Create(Admin _object)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> DeliverPayment(Admin _object)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Admin>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> HandleComplain(Admin _objeect)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> Login(string mail, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> RefoundPayment(Admin _object)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> ShowNotifications(int AccountId, Admin _object)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> TransferPayment(Admin _object)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> Update(Admin _object)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> ValidateUserProfile(Admin _object)
        {
            throw new NotImplementedException();
        }
    }
}
