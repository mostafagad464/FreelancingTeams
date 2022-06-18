using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Reopsitories
{
    public class ReviewRepository : IReview<Review>
    {
        private readonly FreeLanceProjectContext db;
        public ReviewRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }
        public async Task<Review> Create(Review review)
        {
            if (db.Reviews == null)
            {
                return null;
            }
            db.Reviews.Add(review);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReviewExists(review.ClientId, review.TeamId, review.ProjectId))
                {
                    return new Review { Rate = -1 };
                }
                else
                {
                    throw;
                }
            }

            return review;
        }

        public async Task<bool> Delete(int CId, int TId, int PId)
        {
            if (db.Reviews == null)
            {
                return false;
            }
            var review = await db.Reviews.FirstOrDefaultAsync(r=>r.ClientId == CId && r.TeamId == TId && r.ProjectId == PId);
            if (review == null)
            {
                return false;
            }

            db.Reviews.Remove(review);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            if (db.Reviews == null)
            {
                return null;
            }
            return await db.Reviews.ToListAsync();
        }

        public async Task<Review> GetById(int CId, int TId, int PId)
        {
            if (db.Reviews == null)
            {
                return null;
            }
            var review = await db.Reviews.FirstOrDefaultAsync(r => r.ClientId == CId && r.TeamId == TId && r.ProjectId == PId);

            return review;
        }

        public async Task<Review> Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(review.ClientId,review.TeamId,review.ProjectId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return review;
        }
        private bool ReviewExists(int CId, int TId, int PId)
        {
            return (db.Reviews?.Any(e => e.ClientId == CId && e.TeamId == TId && e.ProjectId == PId)).GetValueOrDefault();
        }
    }
}
