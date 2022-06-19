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
    public class UserSocialRepository : IUserSocial<UserSocial>
    {
        private readonly FreeLanceProjectContext db;

        public UserSocialRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public virtual async Task<UserSocial> Create(UserSocial _object)
        {
            try
            {
                var obj = await db.UserSocials.AddAsync(_object);
                await db.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<UserSocial> Delete(int userId, string type)
        {
            try
            {
                var obj = await db.UserSocials.FindAsync(userId, type);
                db.Remove(obj);
                await db.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<IEnumerable<UserSocial>> GetAll()
        {
            try
            {
                return await db.UserSocials.ToListAsync();

            }
            catch (Exception)
            {
                return null;

            }
        }

        public virtual async Task<UserSocial> GetById(int userId, string type)
        {
            try
            {
                return await db.UserSocials.FindAsync(userId, type);
               
            }
            catch (Exception)
            {
                return null;

            }
        }

        public virtual async Task<UserSocial> Update(UserSocial _object)
        {
            try
            {
               
                var obj =  await db.UserSocials.FirstOrDefaultAsync(a => a.UserId == _object.UserId && a.Type == _object.Type);
                obj.Link = _object.Link ;
                
                await db.SaveChangesAsync();

                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
