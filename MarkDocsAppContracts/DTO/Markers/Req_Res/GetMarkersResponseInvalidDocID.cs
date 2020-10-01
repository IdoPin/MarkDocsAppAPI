using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class GetMarkersResponseInvalidDocID : GetMarkersResponse
    {
        public GetMarkersRequest Request { get; }
        public GetMarkersResponseInvalidDocID(GetMarkersRequest request)
        {
            Request = request;
        }
    }
}

