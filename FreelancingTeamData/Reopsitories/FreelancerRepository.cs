using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Reopsitories
{
    public class FreelancerRepository : IFreelancer<Freelancer>
    {
        private readonly FreeLanceProjectContext _db;

        public FreelancerRepository(FreeLanceProjectContext db)
        {
            _db = db;
        }
        public virtual async Task<Freelancer> Create(Freelancer _object)
        {
            if (_object != null)
            {
                try
                {
                    var obj = await _db.Freelancers.AddAsync(_object);
                    await _db.SaveChangesAsync();
                    return _object;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                var obj = await _db.Freelancers.FindAsync(id);
                if (obj != null)
                {
                    _db.Freelancers.Remove(obj);
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

        public virtual async Task<IEnumerable<Freelancer>> GetAll()
        {
            try
            {
                return await _db.Freelancers.Include(c => c.Teams).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Freelancer> GetById(int id)
        {
            try
            {
                var obj = await _db.Freelancers.FindAsync(id);
                if (obj != null)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<IEnumerable<Freelancer>> GetClients()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Freelancer>> GetFreelancers()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Freelancer> Update(Freelancer _object)
        {
            try
            {
                var obj = await _db.Freelancers.FindAsync(_object.Id);
                if (obj != null)
                {
                    obj.TotalMoney = _object.TotalMoney;
                    obj.AVGHourlyRate = _object.AVGHourlyRate;
                    obj.NumberOfClients = _object.NumberOfClients;
                    await _db.SaveChangesAsync();
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
