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

    public class SkillRepository : ISkill<Skill>
    {
        private readonly FreeLanceProjectContext db;

        public SkillRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public virtual async Task<Skill> Create(Skill _object)
        {
            try
            {
                var obj = await db.Skills.AddAsync(_object);
                await db.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                var obj = await db.Skills.FindAsync(id);
                db.Remove(obj);
                await db.SaveChangesAsync();
                if(obj != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<IEnumerable<Skill>> GetAll()
        {

            try
            {

                return await db.Skills.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Skill> GetById(int id)
        {
            try
            {
                return await db.Skills.FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Skill> Update(Skill _object)
        {
            try
            {
              
                var obj = await db.Skills.FindAsync(_object.Id);
               
                obj.Name = _object.Name;
                await db.SaveChangesAsync();

                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
