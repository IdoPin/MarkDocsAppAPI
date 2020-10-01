using DIContracts;
using MarkDocsAppContracts.DTO.WebSocket;
using MarkDocsAppContracts.Interfaces.BLL;
using Newtonsoft.Json;
using SocketContracts;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace WSServices
{
    [Register(Policy.Singleton, typeof(IWSDrawService))]
    public class WSDrawService : IWSDrawService
    {
        ISocket _socket;
        Dictionary<string, List<string>> _users;
        public WSDrawService(ISocket socket)
        {
            _socket = socket;
            _users = new Dictionary<string, List<string>>();
        }
        public async void Add(string userID, string docID, WebSocket socket)
        {
            _socket.Add(userID, socket);
            if (!_users.ContainsKey(docID))
            {
                var users = new List<string>();
                users.Add(userID);
                _users.Add(docID, users);
            }
            else
            {
                _users[docID].Add(userID);
            }
            foreach (var userToSend in _users[docID])
            {
                foreach (var user in _users[docID])
                {
                    var lineReq = new LineRequest();
                    lineReq.UserID = user;
                    var response = JsonConvert.SerializeObject(lineReq);
                    await Send(userToSend, response);
                }

            }
        }

        public async Task Receive(string id, byte[] buffer)
        {
            var request = Encoding.UTF8.GetString(buffer);
            var lineReq = JsonConvert.DeserializeObject<LineRequest>(request);
            var response = JsonConvert.SerializeObject(lineReq);
            foreach (var userToSend in _users[lineReq.DocID])
            {   
                    await Send(userToSend, response);
            }
        }

        public async Task Remove(string userID, string docID)
        {
            await _socket.Remove(userID);
            _users[docID].Remove(userID);
            foreach (var userToSend in _users[docID])
            {

                var lineReq = new LineRequest();
                lineReq.UserID = userID;
                lineReq.X1 = "remove";
                var response = JsonConvert.SerializeObject(lineReq);
                await Send(userToSend, response);

            }


        }

        public async Task Send(string id, string message)
        {
           await _socket.Send(id, message);
        }
    }
}
