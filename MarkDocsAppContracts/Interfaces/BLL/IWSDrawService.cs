using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MarkDocsAppContracts.Interfaces.BLL
{
    public interface IWSDrawService
    {
        Task Send(string id, string message);
        void Add(string userID, string docID, WebSocket socket);
        Task Remove(string userID, string docID);
        Task Receive(string id, byte[] buffer);
    }
}
