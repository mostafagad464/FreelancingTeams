using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Reopsitories
{
    public class FreelancerExperienceRepository : IExperience<FreelancerExperience>
    {
        private readonly FreeLanceProjectContext db;

        public FreelancerExperienceRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public virtual async Task<FreelancerExperience> Create(FreelancerExperience _object)
        {
            if(_object != null)
            {
                try
                {
                    var obj = await db.FreelancerExperiences.AddAsync(_object);
                    await db.SaveChangesAsync();
                    return _object;
                }
                catch (Exception)
                {
                    return null;
                }               
            }
            return null;
            
        }

        public async Task<FreelancerExperience> Delete(int id, DateTime? startDate)
        {
            try
            {
                var obj = await db.FreelancerExperiences.FindAsync(id, startDate);
                if (obj != null)
                {
                    db.FreelancerExperiences.Remove(obj);
                    await db.SaveChangesAsync();
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<IEnumerable<FreelancerExperience>> GetAll()
        {
            try
            {
                return await db.FreelancerExperiences.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<FreelancerExperience> GetById(int id, DateTime? startDate)
        {
            try
            {
                var obj = await db.FreelancerExperiences.FindAsync(id,startDate);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<FreelancerExperience> Update(int id, DateTime? startDate, FreelancerExperience _object)
        {
            try
            {
                var obj = await db.FreelancerExperiences.FindAsync(id, startDate);
                if (obj != null)
                {
                    obj.JobTitle = _object.JobTitle;
                    obj.EndDate = _object.EndDate;
                    obj.CompanyName = _object.CompanyName;
                    obj.CurentllyWorking = _object.CurentllyWorking;
                    obj.JobKind = _object.JobKind;
                    obj.Summary = _object.Summary;
                    await db.SaveChangesAsync();
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            

        }
        public virtual async Task<IEnumerable<FreelancerExperience>> GetAllFreelancerExperiences(int Id)
        {
            try
            {
                var obj = await db.FreelancerExperiences.Where(a => a.FreelancerId == Id).ToListAsync();
                if (obj != null)
                {
                    return obj;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;

        }
    }
}
