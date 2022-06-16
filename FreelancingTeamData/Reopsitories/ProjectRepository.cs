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

        public Task<Project> CancelProject(Project _object)
        {
            throw new NotImplementedException();
        }

        public Task<Project> CheckProjectCompletion(Project _object)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Deal(Project _oject)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> PostProject(Project _object)
        {
            try
            {
                var project = await db.Projects.AddAsync(_object);
                await db.SaveChangesAsync();
                if (project != null)
                    return project.Entity;
                return null;

            }
            catch(Exception)
            {
                return null;
            }
        }


        public Task<Project> Review(Project _oject)
        {
            throw new NotImplementedException();
        }
    }
}
