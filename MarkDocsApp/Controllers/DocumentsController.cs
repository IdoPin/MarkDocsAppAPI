using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Documents.Req_Res;
using MarkDocsAppContracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkDocsApp.Controllers
{
    /*    [Route("api/[controller]")]*/
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private IDocumentService _documnetService;
        public DocumentsController(IDocumentService documnetService)
        {
            _documnetService = documnetService;
        }
        [HttpPost]
        public async Task<Response> CreateDocument(CreateDocumentRequest request)
        {
            return await _documnetService.CreateDocument(request);
        }
        [HttpPost]
        public async Task<Response> GetDocument(GetDocumentRequest request)
        {
            return await _documnetService.GetDocument(request);
        }
        [HttpPost]
        public async Task<Response> GetDocuments(GetDocumentsRequest request)
        {
            return await _documnetService.GetDocuments(request);
        }
        [HttpPost]
        public async Task<Response> RemoveDocument(RemoveDocumentRequest request)
        {
            return await _documnetService.RemoveDocument(request);
        }
    }
}
