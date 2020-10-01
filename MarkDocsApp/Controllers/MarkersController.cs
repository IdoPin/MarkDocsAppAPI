using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Markers.Req_Res;
using MarkDocsAppContracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkDocsApp.Controllers
{
    /*    [Route("api/[controller]")]*/
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class MarkersController : ControllerBase
    {
        private IMarkerService _markerService;
        public MarkersController(IMarkerService markerService)
        {
            _markerService = markerService;
        }
        [HttpPost]
        public async Task<Response> CreateMarker(CreateMarkerRequest request)
        {
            return await _markerService.CreateMarker(request);
        }
        [HttpPost]
        public async Task<Response> GetMarker(GetMarkerRequest request)
        {
            return await _markerService.GetMarker(request);
        }
        [HttpPost]
        public async Task<Response> GetMarkers(GetMarkersRequest request)
        {
            return await _markerService.GetMarkers(request);
        }
        [HttpPost]
        public async Task<Response> RemoveMarker(RemoveMarkerRequest request)
        {
            return await _markerService.RemoveMarker(request);
        }
    }
}
