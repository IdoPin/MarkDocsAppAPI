using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.WebSocket
{
    public class LineRequest
    {
        public string DocID { get; set; }
        public string UserID { get; set; }
        public string X1 { get; set; }
        public string Y1 { get; set; }
        public string X2 { get; set; }
        public string Y2 { get; set; }
    }
}
