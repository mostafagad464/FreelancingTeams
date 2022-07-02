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
    public class UserLanguageRepository : IUserLanguage<UserLanguage>
    {
        private readonly FreeLanceProjectContext db;

        public UserLanguageRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public virtual async Task<UserLanguage> Create(UserLanguage _object)
        {
            try
            {
                var obj = await db.UserLanguages.AddAsync(_object);
                await db.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int userId, string language)
        {
            try
            {
                var obj = await db.UserLanguages.FindAsync(userId, language);
                db.Remove(obj);
                await db.SaveChangesAsync();
                if (obj != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<IEnumerable<UserLanguage>> GetAll()
        {
            try
            {
                return await db.UserLanguages.ToListAsync();

            }
            catch (Exception)
            {
                return null;

            }
        }

        public virtual async Task<UserLanguage> GetById(int userId,string language)
        {
            try
            {
                return await db.UserLanguages.FindAsync(userId, language);
               
            }
            catch (Exception)
            {
                return null;

            }
        }
    }
}
