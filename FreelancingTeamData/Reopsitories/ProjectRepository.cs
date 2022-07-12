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
    public class ProjectRepository:IProject<Project>
    {
        private readonly FreeLanceProjectContext db;
        public ProjectRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<Project> Create(Project _object)
        {
            try
            {
                var project = await db.Projects.AddAsync(_object);
                await db.SaveChangesAsync();
                if (project != null)
                    return project.Entity;
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        Task<bool> ICRUD<Project>.Delete(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> Delete(int id)
        {
            // check for project id if using in another table 

            try
            {
                Project p = new Project();
                p.Id = id;
                var project = db.Projects.Remove(p);
                //p = db.Projects.Remove(p);
                await db.SaveChangesAsync();
                if (project != null)
                    return true;
                //if (p != null)
                //    return p;
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
        

        public async Task<IEnumerable<Project>> GetAll()
        {
            try
            {
                return await db.Projects.ToListAsync();
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Project> GetById(int id)
        {
            try
            {
                //Project project = await db.Projects.FindAsync(id);
                return await db.Projects.Include(p => p.Reviews).FirstOrDefaultAsync(a => a.Id == id);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Project> Update(Project _object)
        {
            try
            {
                var project = db.Projects.Update(_object);
                await db.SaveChangesAsync();
                return project.Entity;
            }
            catch(Exception)
            {
                return null;
            }
        }



        //public async Task<Project> PostProject(Project _object)
        //{
        //    try
        //    {
        //        var project = await db.Projects.AddAsync(_object);
        //        await db.SaveChangesAsync();
        //        if (project != null)
        //            return project.Entity;
        //        return null;

        //    }
        //    catch(Exception)
        //    {
        //        return null;
        //    }
        //}



    }
}
