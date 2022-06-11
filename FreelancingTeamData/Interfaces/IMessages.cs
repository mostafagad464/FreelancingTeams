using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    internal interface IMessages<T>
    {
        public Task<T> SendMessage(Task _object);
        public IEnumerable<Task<T>> GetAllmessages(int SnderId, int ReceiverId);
        
        // Handle This method
        public Task<T> DeleteMessage(int SnderId, int ReceiverId, int MessageID);
        public Task<T> DeleteChat(int SnderId, int ReceiverId);

    }
}
