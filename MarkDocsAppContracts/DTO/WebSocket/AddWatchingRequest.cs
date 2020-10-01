using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.WebSocket
{
    public class AddWatchingRequest
    {
        public string DocID { get; set; }
        public string UserID { get; set; }
    }
}
