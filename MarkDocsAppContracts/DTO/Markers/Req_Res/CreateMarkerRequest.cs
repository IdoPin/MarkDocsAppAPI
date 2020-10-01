using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class CreateMarkerRequest
    {
        public string DocID { get; set; }
        public string UserID { get; set; }
        public string MarkerType { get; set; }
        public string StrokeColor { get; set; }
        public string BackgroundColor { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string XRadius { get; set; }
        public string YRadius { get; set; }
    }
}
