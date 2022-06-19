using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using FreelancingTeamData.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Reopsitories
{
    public class UserCreditRepository : IUserCredit<UserCredit>
    {
        private readonly FreeLanceProjectContext db;

        public UserCreditRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public virtual async Task<UserCredit> Create(UserCredit _object)
        {
            try
            {
                var obj = await db.UserCredits.AddAsync(_object);
                await db.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int userId, int creditNum)
        {
            try
            {
                var obj = await db.UserCredits.FirstOrDefaultAsync(a => a.UserId == userId && a.CreditNumber == creditNum);
                db.Remove(obj);
                await db.SaveChangesAsync();
                if(obj != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<IEnumerable<UserCredit>> GetAll()
        {
            try
            {
                return await db.UserCredits.ToListAsync();
                
            }
            catch(Exception)
            {
                return null;

            }
        }

        public virtual async Task<UserCredit> GetById(int userId, int creditNum)
        {
            try
            {
                return await db.UserCredits.FindAsync(userId, creditNum);
                //return await db.UserCredits.FirstOrDefaultAsync(a=> a.UserId==userId && a.CreditNumber==creditNum);
            }
            catch(Exception)
            {
                return null;

            }
        }

       
    }
}
