using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Markers.Req_Res;
using System.Threading.Tasks;

namespace MarkDocsAppContracts.Interfaces
{
    public interface IMarkerService
    {
        public Task<Response> CreateMarker(CreateMarkerRequest request);
        public Task<Response> GetMarker(GetMarkerRequest request);
        public Task<Response> GetMarkers(GetMarkersRequest request);
        public Task<Response> RemoveMarker(RemoveMarkerRequest request);
    }
}
