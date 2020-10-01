using DIContracts;
using MarkDocsAppContracts.Interfaces.BLL;
using SocketContracts;
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WSServices
{
    [Register(Policy.Singleton, typeof(IWSUserService))]
    public class WSUserService : IWSUserService
    {
        ISocket _socket;
        public WSUserService(ISocket socket)
        {
            _socket = socket;
        }
        public void Add(string id, WebSocket socket)
        {
            _socket.Add(id, socket);
        }

        public async Task Remove(string id)
        {
            await _socket.Remove(id);
        }

        public async Task Send(string id, string message)
        {
            await _socket.Send(id, message);
        }
    }
}
