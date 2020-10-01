using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Markers.Req_Res
{
    public class GetMarkersResponseOK : GetMarkersResponse
    {
        public List<Marker> Markers { get; }
        public GetMarkersResponseOK(List<Marker> markers)
        {
            Markers = markers;
        }
    }
}

