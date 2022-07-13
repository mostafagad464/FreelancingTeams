using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IMessages<T>
    {
        public Task<IEnumerable<T>> GetChat(int SnderId, int ReceiverId);
        public Task<IEnumerable<T>> GetAllChats(int UserId, string? type);
        public Task<T> SendMessage(T _object);
        public Task<IEnumerable<T>> SetChatRead(int SnderId, int ReceiverId, string? Sender);
        // Handle This method
        //public Task<T> DeleteMessage(int SenderId, int ReceiverId, int MessageID);
        //public Task<T> DeleteChat(int SnderId, int ReceiverId);

    }
}
