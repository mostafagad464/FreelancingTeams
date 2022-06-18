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
    public class AccountRepository : IAccount<Account>
    {

        private readonly FreeLanceProjectContext db;

        public AccountRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public virtual async Task<Account> Create(Account _object)
        {
            try
            {
                var obj = await db.Accounts.AddAsync(_object);
                await db.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Account> Delete(int id)
        {
            try
            {
                var obj = await db.Accounts.FindAsync(id);
                db.Remove(obj);
                await db.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // I think implimentation must be in admin
        public virtual async Task<IEnumerable<Account>> GetAll()
        {
            try
            {
                return await db.Accounts.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Account> GetById(int id)
        {
            try
            {
                return await db.Accounts.FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Account> Login(string email, string password)
        {
            try
            {
                var obj = await db.Accounts.Where(e => e.Email == email && e.Password == password).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<Account> ShowNotifications(int AccountId, Account _object)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Account> Update(Account _object)
        {
            try
            {
                var obj = await db.Accounts.FindAsync(_object.Id);
                obj.FirstName = _object.FirstName;
                obj.LastName = _object.LastName;
                obj.Email = _object.Email;
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
