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
    public class CategoryRepository : ICategory<Category>
    {
        private readonly FreeLanceProjectContext db;

        public CategoryRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public virtual async Task<Category> Create(Category _object)
        {
            try
            {
                var obj = await db.Categories.AddAsync(_object);
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
                var obj = await db.Categories.FindAsync(id);
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

        public virtual async Task<IEnumerable<Category>> GetAll()
        {

            try
            {
                return await db.Categories.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Category> GetById(int id)
        {
            try
            {
                return await db.Categories.FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<Category> Update(Category _object)
        {
            try
            {
                Console.WriteLine("id", _object.Id);
                var obj = await db.Categories.FindAsync(_object.Id);
                Console.WriteLine("name",obj.Name);
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
