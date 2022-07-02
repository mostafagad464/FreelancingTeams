using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Models;
using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Reopsitories
{
    public class TeamTransactionRepository : ITeamTransactions<TeamTransaction>
    {
        private readonly FreeLanceProjectContext db;
        public TeamTransactionRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<bool> DeleteTeamTransactions(List<TeamTransaction> _objects)
        {
            try
            {
                for (int i = 0; i < _objects.Count; i++)
                {
                    db.TeamTransactions.Remove(_objects[i]);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<TeamTransaction>> EditTeamTransactions(List<TeamTransaction> _objects)
        {
            try
            {
                List<TeamTransaction> teamTransactions = new List<TeamTransaction>();

                for (int i = 0; i < _objects.Count; i++)
                {
                    var t = db.TeamTransactions.Update(_objects[i]);
                    await db.SaveChangesAsync();
                    teamTransactions.Add(t.Entity);
                }
                return teamTransactions;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<TeamTransaction>> GetAllTeamTransactions()
        {
            if (db.TeamTransactions == null)
                return null;
            return await db.TeamTransactions.ToListAsync();
        }

        public async Task<TeamTransaction> GetTeamTransactions(int id)
        {
            try
            {
                return await db.TeamTransactions.FindAsync(id);
            }
            catch(Exception )
            {
                return null;
            }
        }

        public async Task<List<TeamTransaction>> CreateTeamTransactions(List<TeamTransaction> _objects)
        {
            try
            {
                //TeamTransaction teamTransaction = new TeamTransaction();
                List<TeamTransaction> teamTransactions = new List<TeamTransaction>();

                for (int i = 0; i < _objects.Count; i++)
                {
                    //if(_objects[i].TeamId>0 && _objects[i].ProjectId>0 && _objects[i].FreelancerId)
                    //{

                    //}
                    var t = await db.TeamTransactions.AddAsync(_objects[i]);
                    await db.SaveChangesAsync();
                    teamTransactions.Add(t.Entity);
                }
                return teamTransactions;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

       
    }
}
