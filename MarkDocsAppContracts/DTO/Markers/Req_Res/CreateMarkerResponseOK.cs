using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class CreateMarkerResponseOK : CreateMarkerResponse
    {
        public CreateMarkerRequest Request { get; }
        public CreateMarkerResponseOK(CreateMarkerRequest request)
        {
            Request = request;
        }
    }
}

