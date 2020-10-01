using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketContracts
{
    public interface ISocket
    {
        Task Send(string id, string message);
        void Add(string id, WebSocket socket);
        Task Remove(string id);
        Dictionary<string, WebSocket> GetAllSockets();
    }
}
