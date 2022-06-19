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
    internal class ProjectPaymentRepository : IProjectPayment<ProjectPayment>
    {
        private readonly FreeLanceProjectContext db;
        public ProjectPaymentRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public async Task<ProjectPayment> Create(ProjectPayment _object)
        {
            throw new NotImplementedException();

        }

        public Task<ProjectPayment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectPayment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectPayment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectPayment> Update(ProjectPayment _object)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICRUD<ProjectPayment>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
