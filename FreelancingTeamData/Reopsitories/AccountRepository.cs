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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                return await db.Accounts.Include(a=>a.User).ThenInclude(u=>u.FreelancerNavigation).FirstOrDefaultAsync(a=>a.Id==id);
            }
            catch
            {
                return null;
            }
        }

        public virtual async Task<string> UniqueUserName(string FirstName, string LastName)
        {
            string UserName;
            Account account;
            int? i = null;
            do
            {
                UserName = FirstName.ToLower() + LastName.ToLower() + i.ToString(); ;
                account = await db.Accounts.Where(a => a.Username == UserName).FirstOrDefaultAsync();
                i = (i == null) ? 1 : i + 1;
            } while (account!=null);

            return UserName;
        }

        public virtual async Task<Account> Update(Account account)
        {
            try
            {
                var oldaccount = await db.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == account.Id);
                account.Password = oldaccount.Password;
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
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<Account> Login(string usernameORemail, string password)
        {
            try
            {
                var obj = await db.Accounts.Where(e => (e.Email == usernameORemail || e.Username == usernameORemail) && e.Password == password).Include(a => a.User).FirstOrDefaultAsync();
                if(obj != null)
                {
                    obj.User.ActiveStatus = true;
                    db.SaveChanges();
                }
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Account> Logout(int id)
        {
            try
            {
                var obj = await db.Accounts.Where(e => e.Id == id).Include(a => a.User).FirstOrDefaultAsync();
                if (obj != null)
                {
                    obj.User.ActiveStatus = false;
                    db.SaveChanges();
                }
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
