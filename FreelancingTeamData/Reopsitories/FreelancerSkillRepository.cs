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
    public class FreelancerSkillRepository : IEducationSkill<FreelancerSkill>
    {
        private readonly FreeLanceProjectContext _db;

        public FreelancerSkillRepository(FreeLanceProjectContext db)
        {
            _db = db;
        }
        public virtual async Task<FreelancerSkill> Create(FreelancerSkill _object)
        {

            if (_object != null)
            {
                try
                {
                    var obj = await _db.FreelancerSkills.AddAsync(_object);
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

        public virtual async Task<FreelancerSkill> Delete(int freelancerId, int skillId)
        {
            try
            {
                var obj = await _db.FreelancerSkills.FindAsync(freelancerId, skillId);
                if (obj != null)
                {
                    _db.FreelancerSkills.Remove(obj);
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

        public virtual async Task<IEnumerable<FreelancerSkill>> GetAll()
        {
            try
            {
                return await _db.FreelancerSkills.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<FreelancerSkill> GetById(int freelancerId, int skillId)
        {
            try
            {
                var obj = await _db.FreelancerSkills.FindAsync(freelancerId, skillId);
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

        public virtual async Task<IEnumerable<FreelancerSkill>> GetSkillCategoryNamesById(int Id)
        {
            try
            {
            
                var obj = await _db.FreelancerSkills.Where(a => a.FreelancerId == Id).Include(s => s.Skill).ToListAsync();
               
                if (obj != null)
                {
                    return obj;
                }
                return null;
            }
            catch(Exception)
            {
                return null;

            }
        }

        public virtual async Task<FreelancerSkill> Update(int freelancerId, int skillId, FreelancerSkill _object)
        {
            try
            {
                var obj = await _db.FreelancerSkills.FindAsync(freelancerId, skillId);
                if (obj != null)
                {
                    obj.EfficiancyRate = _object.EfficiancyRate;
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

        Task<IEnumerable<FreelancerSkill>> IEducationSkill<FreelancerSkill>.GetEducationById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
