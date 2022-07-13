using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Reopsitories
{
    public class UserRepository : IUser<User>
    {
        private readonly FreeLanceProjectContext db;
        public UserRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public async Task<User> Create(User user)
        {
            if (db.Users == null)
            {
                return null;
            }
            try
            {
                await db.Users.AddAsync(user);
                if (user.Freelancer == true && user.FreelancerNavigation == null)
                {
                    await db.Freelancers.AddAsync(new Freelancer() { Id = user.Id });
                }
                else if(user.Client == true && user.ClientNavigation == null)
                {
                    await db.Clients.AddAsync(new Client() { Id = user.Id });
                }
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return new User { Id = 0 };
                }
                else
                {
                    throw;
                }
            }

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            if (db.Users == null)
            {
                return false;
            }
            var user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            if (db.Users == null)
            {
                return null;
            }
            return await db.Users.Include(u=>u.FreelancerNavigation).Include(u=>u.ClientNavigation).ToListAsync();
        }
        public async Task<IEnumerable<User>> GetClients()
        {
            if (db.Users == null)
            {
                return null;
            }
            
            return await db.Users.Where(u=>u.Client == true).Include(u => u.ClientNavigation).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetFreelancers()
        {
            if (db.Users == null)
            {
                return null;
            }

            return await db.Users.Where(u => u.Freelancer == true).Include(u => u.FreelancerNavigation).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            if (db.Users == null)
            {
                return null;
            }
            var user = await db.Users.Include(u => u.ClientNavigation).Include(u => u.FreelancerNavigation).ThenInclude(f => f.TeamMembers).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }


        public async Task<User> Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
                if(user.ClientNavigation != null)
                {
                    user.ClientNavigation.Id = user.Id;
                    db.Entry(user.ClientNavigation).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                if (user.FreelancerNavigation != null)
                {
                    user.FreelancerNavigation.Id = user.Id;
                    db.Entry(user.FreelancerNavigation).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return user;
        }

        public async Task<Byte[]> SetImage(int UserId, IFormFile image)
        {
            Stream stream = image.OpenReadStream();
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
            db.Users.FirstOrDefault(a => a.Id == UserId).Image = bytes;
            db.SaveChanges();
            return bytes;
        }

        public async Task<Byte[]> GetImage(int UserId)
        {
            var user = await db.Users.FirstOrDefaultAsync(a => a.Id == UserId);
            return user?.Image;
        }

        private bool UserExists(int id)
        {
            return (db.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
