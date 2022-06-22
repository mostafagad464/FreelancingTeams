using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace FreelancingTeamData.Reopsitories
{
    public class ProposalRepository : IProposal<Proposal>
    {
        FreeLanceProjectContext db = new FreeLanceProjectContext();

        public ProposalRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public async Task<Proposal> Create(Proposal _object)
        {
            db.Proposals.Add(_object);
            await db.SaveChangesAsync();

            return _object;
        }

        public async Task<bool> Delete(int id)
        {
            var propos = await db.Proposals.FindAsync(id);
            if (propos == null)
            {
                return false;
            }

            db.Proposals.Remove(propos);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Proposal>> GetAll()
        {
            var propos = await db.Proposals.ToListAsync();
            return propos;
        }

        public async Task<Proposal> GetById(int id)
        {
            var propos = await db.Proposals.FindAsync(id);
            return propos;
        }

        public async Task<Proposal> Update(Proposal _object)
        {
            db.Entry(_object).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return _object;
        }

        public bool ProposalExists(int id)
        {
            return db.Proposals.Any(e => e.Id == id);
        }
    }
}
