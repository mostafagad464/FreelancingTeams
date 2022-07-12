using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FreelancingTeamData.Reopsitories
{
    public class FreelancerCertificateRepository : ICertificate<FreelancerCertificate>
    {
        private readonly FreeLanceProjectContext _db;

        public FreelancerCertificateRepository(FreeLanceProjectContext db)
        {
            _db = db;
        }
        public virtual async Task<FreelancerCertificate> Create(FreelancerCertificate _object)
        {
            if (_object != null)
            {
                try
                {
                    var obj = await _db.FreelancerCertificates.AddAsync(_object);
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

        public virtual async Task<FreelancerCertificate> Delete(int freelancerId, string title)
        {
            try
            {
                var obj = await _db.FreelancerCertificates.FindAsync(freelancerId, title);
                if (obj != null)
                {
                    _db.FreelancerCertificates.Remove(obj);
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

        public virtual async Task<IEnumerable<FreelancerCertificate>> GetAll()
        {
            try
            {
                return await _db.FreelancerCertificates.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<FreelancerCertificate> GetById(int freelancerId, string title)
        {
            try
            {
                var obj = await _db.FreelancerCertificates.FindAsync(freelancerId, title);
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

        public virtual async Task<FreelancerCertificate> Update(int freelancerId, string title, FreelancerCertificate _object)
        {
            try
            {
                var obj = await _db.FreelancerCertificates.FindAsync(freelancerId, title);
                if (obj != null)
                {
                    obj.Link = _object.Link;
                    obj.Organization = _object.Organization;
                    obj.Date = _object.Date;
                    obj.Description = _object.Description;
                    obj.Specialization = _object.Specialization;
                    await _db.SaveChangesAsync();
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

        public virtual async Task<IEnumerable<FreelancerCertificate>> GetAllFreelancerCertificates(int Id)
        {
            try
            {
                var obj = await _db.FreelancerCertificates.Where(a => a.FreelancerId == Id).ToListAsync();
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
