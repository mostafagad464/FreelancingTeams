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

namespace FreelancingTeamData.Reopsitories
{
    public class UserRepository : IUser<User>
    {
        FreeLanceProjectContext db= new FreeLanceProjectContext();
        UserRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<User> CompleteProfile(User _object)
        {
            try
            {
                var obj = await db.Users.AddAsync(_object);
                await db.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
