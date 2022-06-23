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
    public class FreelancerEducationRepository : IEducationSkill<FreelancerEducation>
    {
        private readonly FreeLanceProjectContext _db;

        public FreelancerEducationRepository(FreeLanceProjectContext db)
        {
            _db = db;
        }
        public virtual async Task<FreelancerEducation> Create(FreelancerEducation _object)
        {
            if(_object != null)
            {
                try
                {
                    var obj = await _db.FreelancerEducations.AddAsync(_object);
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

        public virtual async Task<FreelancerEducation> Delete(int freelancerId, int id)
        {
            try
            {
                var obj = await _db.FreelancerEducations.FindAsync(freelancerId, id);
                if (obj != null)
                {
                    _db.FreelancerEducations.Remove(obj);
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

        public async Task<IEnumerable<FreelancerEducation>> GetAll()
        {
            try
            {
                return await _db.FreelancerEducations.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<FreelancerEducation> GetById(int freelancerId, int id)
        {
            try
            {
                var obj = await _db.FreelancerEducations.FindAsync(freelancerId, id);
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

        public virtual async Task<FreelancerEducation> Update(int freelancerId, int id, FreelancerEducation _object)
        {
            try
            {
                var obj = await _db.FreelancerEducations.FindAsync(freelancerId, id);
                if (obj != null)
                {
                    obj.Grade = _object.Grade;
                    obj.Faculty = _object.Faculty;
                    obj.University = _object.University;
                    obj.Department = _object.Department;
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
