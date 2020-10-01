using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MarkDocsAppContracts.Interfaces.BLL
{
    public interface IWSUserService
    {
        Task Send(string id, string message);
        void Add(string id, WebSocket socket);
        Task Remove(string id);
    }
}
