using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Sharing.Req_Res;
using System.Threading.Tasks;

namespace MarkDocsAppContracts.Interfaces
{
    public interface ISharingService
    {
        public  Task<Response> CreateShare(CreateShareRequest request);
        public Task<Response> GetSharedDocuments(GetSharedDocumentsRequest request);
        public Task<Response> GetSharedUsers(GetSharedUsersRequest request);
        public Task<Response> RemoveShare(RemoveShareRequest request);
    }
}
