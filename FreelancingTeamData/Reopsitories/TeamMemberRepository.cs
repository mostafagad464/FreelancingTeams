using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using FreelancingTeamData.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace FreelancingTeamData.Reopsitories
{
    public class TeamMemberRepository : ITeamMember<TeamMember>
    {
        private readonly FreeLanceProjectContext _db;

        public TeamMemberRepository(FreeLanceProjectContext db)
        {
            _db = db;
        }

        static string connectionString = "Server=projectdatabase.database.windows.net;Database=FreelancingTeams;User ID=noah;Password=pass123$;";
        static string procedure = "GetMembers";

        static SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(procedure, con);
        SqlDataReader r;


        public virtual async Task<TeamMember> AddTeamMember(TeamMember _object)
        {
            if (_object != null)
            {
                try
                {
                    var obj = await _db.TeamMembers.AddAsync(_object);
                    await _db.SaveChangesAsync();
                    return _object;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public virtual async Task<bool> Delete(int teamId, int freelancerId)
        {
            try
            {
                var obj = await _db.TeamMembers.FindAsync(teamId, freelancerId);
                if (obj != null)
                {
                    _db.TeamMembers.Remove(obj);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public Task<IEnumerable<TeamMember>> GetAll()
        //{
        //    try
        //    {
        //        return await _db.FreelancerEducations.ToListAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        public virtual async Task<IEnumerable<int>> GetTeamMembers(int id)
        {
            try
            {
                List<int> ids = new List<int> {  };
                var obj = await _db.Teams.Include(c => c.TeamMembers).FirstOrDefaultAsync(i => i.Id == id);
                if (obj != null)
                {
                    foreach(var i in obj.TeamMembers)
                    {
                        ids.Add(i.FreelancerId);
                    }
                    return ids;
                }
                
                return ids;
            }
            catch (Exception)
            {
                return null;
            }           
        }

        public async Task<TeamMember> GetFreelancer(TeamMember teamMemberRecived)
        {
            try
            {
                TeamMember teamMember = new TeamMember();
                teamMember = await _db.TeamMembers.Where(a => a.TeamId == teamMemberRecived.TeamId && a.FreelancerId == teamMemberRecived.FreelancerId).FirstOrDefaultAsync();
                return teamMember;
            }
            catch
            {
                return null;
            }
        }


        public Task<TeamMember> Update(int teamId, int freelancerId, TeamMember _object)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<IEnumerable<TeamMember>> GetMembers(int teamId)
        {
            string StoredProc = "exec GetMembers " +
                    "@ID = " + teamId + "," ;

            //return await _context.output.ToListAsync();
            return await _db.TeamMembers.FromSqlRaw(StoredProc).ToListAsync();
        }
    }

 }