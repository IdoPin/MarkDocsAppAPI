using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class GetMarkerResponseInvalid : GetMarkerResponse
    {
        public GetMarkerRequest Request { get; }
        public GetMarkerResponseInvalid(GetMarkerRequest request)
        {
            Request = request;
        }
    }
}
