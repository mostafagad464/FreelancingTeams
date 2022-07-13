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
    public class PortoflioRepository : IPortoflio<Portoflio>
    {

        FreeLanceProjectContext db=new FreeLanceProjectContext();
        public PortoflioRepository(FreeLanceProjectContext _db)
        {
            db= _db;

        }

        public async Task<Portoflio> Create(Portoflio _object)
        {
            try
            {
                await db.AddAsync(_object);
                db.SaveChanges();
                
                return _object;
            }
            catch (Exception ex)
            {
                return null;

            }



        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                Portoflio portoflio = await db.Portoflios.FindAsync(id);
                var p = db.Portoflios.Remove(portoflio);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            { return false; }
        }

        public virtual async Task<IEnumerable<Portoflio>> GetAll()
        {
            try
            {
                return await db.Portoflios.ToListAsync();
            }
            catch(Exception)
            {
                return null;
            }
            

        }

        public async Task<Portoflio> GetById(int id)
        {
            if(db.Portoflios==null)
            {
                return null;
            }
            Portoflio portof = await db.Portoflios.FindAsync(id);
            if(portof ==null)
            {
                return null;
            }
            return portof;
        }

        public async Task<Portoflio> Update(Portoflio newPortoflio)
        {
            try {

                db.Entry(newPortoflio).State = EntityState.Modified;
                //var neededPortoflio =await db.Portoflios.FindAsync(id);
                //neededPortoflio.Description= newPortoflio.Description;
                //neededPortoflio.FreelancerId = newPortoflio.FreelancerId;
                //neededPortoflio.Title = newPortoflio.Title;
                //neededPortoflio.Link= newPortoflio.Link;
                await db.SaveChangesAsync();
                return newPortoflio;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual async Task<IEnumerable<Portoflio>> GetFreelancerPortfolio(int id)
        {
            try
            {
                return await db.Portoflios.Where(a => a.FreelancerId == id).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }


        }
    }
}
