using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class GetMarkerResponseOK : GetMarkerResponse
    {
        public Marker Marker { get; }
        public GetMarkerResponseOK(Marker marker)
        {
            Marker = marker;
        }
    }
}
