using DIContracts;
using SocketContracts;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket
{
    [Register(Policy.Transient, typeof(ISocket))]
    public class Socket : ISocket
    {
        Dictionary<string, WebSocket> _sockets;
        public Socket()
        {
            _sockets = new Dictionary<string, WebSocket>();
        }
        public void Add(string id, WebSocket socket)
        {
            if (!_sockets.ContainsKey(id))
            {
                _sockets.Add(id, socket);
            }
        }

        public async Task Remove(string id)
        {
            _sockets.Remove(id, out WebSocket socketToRemove);
            await socketToRemove.CloseAsync(WebSocketCloseStatus.NormalClosure, "socket connection closed",
                CancellationToken.None);
        }

        public async Task Send(string id, string message)
        {
            if (_sockets.ContainsKey(id))
            {
                var buffer = Encoding.UTF8.GetBytes(message);
                await _sockets[id].SendAsync(new ReadOnlyMemory<byte>(buffer), WebSocketMessageType.Text
                    , true
                   , CancellationToken.None);
            }
        }
        public Dictionary<string, WebSocket> GetAllSockets()
        {
            return _sockets;
        }
    }
}
