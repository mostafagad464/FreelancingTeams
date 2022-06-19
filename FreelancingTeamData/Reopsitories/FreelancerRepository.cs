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
    public class FreelancerRepository : IFreelancer<Freelancer>
    {
        public Task<Freelancer> CompleteProfile(Freelancer _object)
        {
            throw new NotImplementedException();
        }

        public Task<Freelancer> Create(Freelancer _object)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Freelancer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Freelancer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Freelancer> Login(string mail, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Freelancer> ShowNotifications(int AccountId, Freelancer _object)
        {
            throw new NotImplementedException();
        }

        public Task<Freelancer> Update(Freelancer _object)
        {
            throw new NotImplementedException();
        }
    }
}
