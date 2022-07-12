using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Models
{
    public partial class TeamImage
    {
        public int id { get; set; }   
        
        public byte[] content { get; set; }
    }
}
