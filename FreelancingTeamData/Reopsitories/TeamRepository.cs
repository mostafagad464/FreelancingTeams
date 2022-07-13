using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Data;
using FreelancingTeamData.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Reopsitories
{
    public class TeamRepository : ITeam<Team>
    {
        FreeLanceProjectContext db;

        public TeamRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<Team> Create(Team _object)
        {

            try
            {
                var team = await db.Teams.AddAsync(_object);
                await db.SaveChangesAsync();
                //return await db.Teams.FindAsync(_object.Id);
                return team.Entity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (db.Teams == null)
            {
                return false;
            }
            var team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return false;
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();


            return true;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            try
            {
                var list = await db.Teams.ToListAsync();
                return list;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Team> GetById(int id)
        {
            try
            {

                return await db.Teams.Include(t => t.TeamMembers).Include(t => t.Deals).FirstOrDefaultAsync(a => a.Id == id);
            }
            catch
            {
                return null;

            }
        }

        //public Task<Team> GetNotifications(int TeamID, Team _object)
        //{
        //    throw new NotImplementedException();
        //}

        //public async IEnumerable<Task<Team>> GetTeamMemebers(int TeamID)
        //{
        //    try
        //    {
        //        return await db.Teams.Find(a=>a.TeamMember);
        //    }
        //    catch
        //    {
        //        return null;

        //    }
        //}

        public Task<Team> OfferProposal(Team _object)
        {
            throw new NotImplementedException();
        }

        public Task<Team> SerchForProject(IEnumerable<Team> _objects)
        {
            throw new NotImplementedException();
        }

        public Task<Team> SubmitProject(Team _object)
        {
            throw new NotImplementedException();
        }

        public async Task<Team> Update(Team _object)
        {
            try
            {
                var obj = await db.Teams.FindAsync(_object.Id);

                //virtual nav prop lessa..

                obj.Logo = _object.Logo;
                obj.CreationDate = _object.CreationDate;
                obj.Description = _object.Description;
                obj.Rate = _object.Rate;
                obj.IsVerfied = _object.IsVerfied;
                obj.WebSite = _object.WebSite;
                obj.LeaderId = _object.LeaderId;
                obj.WalletId = _object.WalletId;

                db.Entry(obj).State = EntityState.Modified;
                db.Teams.Update(obj);


                await db.SaveChangesAsync();
                return await db.Teams.Include(t => t.TeamMembers).FirstOrDefaultAsync(a => a.Id == _object.Id);
            }
            catch
            {
                return null;
            }
        }
        public async Task<Team> AddTeamMember(TeamMember teamMember)
        {
            try
            {
                await db.TeamMembers.AddAsync(teamMember);
                await db.SaveChangesAsync();

                return await db.Teams.Include(t => t.TeamMembers).ThenInclude(m => m.Freelancer).FirstOrDefaultAsync(a => a.Id == teamMember.TeamId);

            }
            catch (Exception ex)
            {

                return new Team() { Description = ex.Message };
            }

        }


    }
}
