using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class RemoveMarkerResponseOK : RemoveMarkerResponse
    {
        public RemoveMarkerRequest Request { get; }
        public RemoveMarkerResponseOK(RemoveMarkerRequest request)
        {
            Request = request;
        }
    }
}

