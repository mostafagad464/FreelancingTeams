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
    public class DealRepository:IDeal<Deal>
    {
        FreeLanceProjectContext db = new FreeLanceProjectContext();

        public DealRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<Deal> DeleteDeal(int clientId , int TeamId , int projectId)
        {
            var deal = await db.Deals.FindAsync(clientId , TeamId , projectId);
            if (deal == null)
            {
                return deal;
            }

            db.Deals.Remove(deal);
            await db.SaveChangesAsync();

            return deal;
        }

        public async Task<Deal> HireTeam(Deal _object)
        {
            Console.WriteLine("done");
            db.Deals.Add(_object);
            await db.SaveChangesAsync();

            return _object;
        }

        public async Task<Deal> ProjectCompleted(int clientId, int TeamId, int projectId)
        {
            var deal = await db.Deals.FindAsync(clientId, TeamId, projectId);
            if (deal == null)
                return deal;

            deal.Done = null;
            await db.SaveChangesAsync();
            return deal;
        }

        public async Task<Deal> GetDeal(int clientId, int TeamId, int projectId)
        {
            var deal = await db.Deals.FindAsync(clientId, TeamId, projectId);
            return deal;
        }
        
        public async Task<Deal> UpdateDeal(Deal d)
        {
            db.Entry(d).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return d;
        }
        public bool DealExists(int clientId, int TeamId, int projectId)
        {
            return db.Deals.Any(e => e.ClientId == clientId && e.TeamId == TeamId && e.ProjectId == projectId);
        }
    }
}
