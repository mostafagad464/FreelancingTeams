using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Reopsitories
{
    public  class ComplainRepository : IComplain<Complain>
    {
        private readonly FreeLanceProjectContext db;

        public ComplainRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public virtual async Task<Complain> Create(Complain _object)
        {
            var obj = await db.Complains.AddAsync(_object);
            await db.SaveChangesAsync();
            return _object;

        }


        public virtual async Task<Complain> Delete(int id)
        {
            var obj = await db.Complains.FindAsync(id);
            if(obj != null)
            {
                db.Complains.Remove(obj);
                await db.SaveChangesAsync();
                return obj;
            }
            else
            {
                return null;
            }
            
        }

        public virtual async Task<IEnumerable<Complain>> GetAll()
        {
            try
            {
                return await db.Complains.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Complain> GetById(int id)
        {
            try
            {
                return await db.Complains.FindAsync(id);
            }
            catch(Exception)
            {
                return null;
            }
        }

      
        public virtual async Task<Complain> Update(Complain _object)
        {
            try
            {
                var obj = await db.Complains.FindAsync(_object.Id);
                obj.AdminHandlerId= _object.AdminHandlerId;
                obj.ComplainingUserId = _object.ComplainingUserId;  
                obj.ComplainingTeamId= _object.ComplainingTeamId;
                obj.Description= _object.Description;   
                obj.Type= _object.Type;
                await db.SaveChangesAsync();
                return obj;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Complain> IsHandeled(Complain _object)
        {
            return await db.Complains.FindAsync(_object.Id);
        }
    }
}
