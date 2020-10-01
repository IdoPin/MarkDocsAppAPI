using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Sharing.Req_Res;
using MarkDocsAppContracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkDocsApp.Controllers
{
/*    [Route("api/[controller]")]*/
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class SharesController : ControllerBase
    {
        private ISharingService _sharingService;

        public SharesController(ISharingService sharingService)
        {
            _sharingService = sharingService;
        }
        [HttpPost]
        public async Task<Response> CreateShare(CreateShareRequest request)
        {
            return await _sharingService.CreateShare(request);
        }
        [HttpPost]
        public async Task<Response> GetSharedDocuments(GetSharedDocumentsRequest request)
        {
            return await _sharingService.GetSharedDocuments(request);
        }
        [HttpPost]
        public async Task<Response> GetSharedUsers(GetSharedUsersRequest request)
        {
            return await _sharingService.GetSharedUsers(request);
        }
        [HttpPost]
        public async Task<Response> RemoveShare(RemoveShareRequest request)
        {
            return await _sharingService.RemoveShare(request);
        }
    }
}
