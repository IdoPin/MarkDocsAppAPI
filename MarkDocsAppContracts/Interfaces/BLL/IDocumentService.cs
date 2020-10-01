using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Documents.Req_Res;
using System.Threading.Tasks;

namespace MarkDocsAppContracts.Interfaces
{
    public interface IDocumentService
    {
        public Task<Response> CreateDocument(CreateDocumentRequest request);
        public Task<Response> GetDocument(GetDocumentRequest request);
        public Task<Response> GetDocuments(GetDocumentsRequest request);
        public Task<Response> RemoveDocument(RemoveDocumentRequest request);
    }
}
