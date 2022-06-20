using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IProposal<T>:ICRUD<T>
    {
        public bool ProposalExists(int id);
    }
}
