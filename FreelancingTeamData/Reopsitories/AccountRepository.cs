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

        public virtual async Task<Account> Create(Account account)
        {
            try
            {
                if (db.Accounts == null)
                {
                    return null;
                }
                db.Accounts.Add(account);
                await db.SaveChangesAsync();
                if(account.Type == "Admin")
                {
                    if (db.Admins == null)
                    {
                        return null;
                    }
                    db.Admins.Add(new Admin { Id = account.Id});
                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        if (AdminExists(account.Id))
                        {
                            return new Account { Id = 0 };
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return account;
            }
            catch
            {
                return null;
            }
        }

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                if (db.Accounts == null)
                {
                    return false;
                }
                var account = await db.Accounts.FindAsync(id);
                if (account == null)
                {
                    return false;
                }
                if(account.Type == "Admin")
                {
                    var admin = await db.Admins.FindAsync(id);
                    db.Admins.Remove(admin);
                    await db.SaveChangesAsync();
                }
                db.Accounts.Remove(account);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
     
        
        public virtual async Task<IEnumerable<Account>> GetAll()
        {
            try
            {
                if (db.Accounts == null)
                {
                    return null;
                }
                return await db.Accounts.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<Account>> GetAdmins()
        {
            if (db.Accounts == null)
            {
                return null;
            }
            return await db.Accounts.Where(a => a.Type == "Admin").ToListAsync();
        }

        public virtual async Task<Account> GetById(int id)
        {
            try
            {
                if (db.Accounts == null)
                {
                    return null;
                }
                return await db.Accounts.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public virtual async Task<Account> Update(Account account)
        {
            try
            {
                db.Entry(account).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
                return account;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Account> Login(string usernameORemail, string password)
        {
            try
            {
                var obj = await db.Accounts.Where(e => (e.Email == usernameORemail || e.Username == usernameORemail) && e.Password == password).FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private bool AccountExists(int id)
        {
            return (db.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool AdminExists(int id)
        {
            return (db.Admins?.Any(e => e.Id == id)).GetValueOrDefault();
        }

       



        //public Task<Account> ShowNotifications(int AccountId, Account _object)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
