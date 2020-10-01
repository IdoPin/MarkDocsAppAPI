using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class CreateMarkerResponseInvalidMarkerData : CreateMarkerResponse
    {
        public CreateMarkerRequest Request { get; }
        public CreateMarkerResponseInvalidMarkerData(CreateMarkerRequest request)
        {
            Request = request;
        }
    }
}

