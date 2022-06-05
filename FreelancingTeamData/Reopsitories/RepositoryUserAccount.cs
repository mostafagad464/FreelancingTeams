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
    public class RepositoryUserAccount : ICRUD<UserAccount>, IPerson<UserAccount>
    {

        private readonly FreeLanceProjectContext db;

        public RepositoryUserAccount(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<UserAccount> Create(UserAccount _object)
        {
            try
            {
                var obj = await db.UserAccounts.AddAsync(_object);
                await db.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserAccount> Delete(int id)
        {
            try
            {
                var obj = await db.UserAccounts.FindAsync(id);
                db.Remove(obj);
                await db.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserAccount>> GetAll()
        {
            try
            {
                return await db.UserAccounts.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserAccount> GetById(int id)
        {
            try
            {
                return await db.UserAccounts.FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserAccount> Login(string mail, string password)
        {
            try
            {
                var obj = await db.UserAccounts.Where(u=> u.Email == mail && u.Password == password).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public bool Register(UserAccount _object)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<UserAccount> Update(int id, UserAccount _object)
        {
            try
            {
                var obj = await db.UserAccounts.FindAsync(id);
                obj.FName = _object.FName;
                obj.LName = _object.LName;
                obj.Email = _object.Email;
                obj.Country = _object.Country;
                obj.Password = _object.Password;
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
