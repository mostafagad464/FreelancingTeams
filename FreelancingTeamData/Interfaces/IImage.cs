using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IImage
    {
        public Task<Byte[]> SetImage(int UserId, IFormFile image);
        public Task<Byte[]> GetImage(int UserId);
    }
}
