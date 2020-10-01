using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class RemoveMarkerResponseInvalidMarkerID : RemoveMarkerResponse
    {
        public RemoveMarkerRequest Request { get; }
        public RemoveMarkerResponseInvalidMarkerID(RemoveMarkerRequest request)
        {
            Request = request;
        }
    }
}

