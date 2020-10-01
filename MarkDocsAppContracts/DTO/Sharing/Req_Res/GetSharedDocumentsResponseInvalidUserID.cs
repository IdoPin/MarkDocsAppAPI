using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Sharing.Req_Res
{
    public class GetSharedDocumentsResponseInvalidUserID : GetSharedDocumentsResponse
    {
        public GetSharedDocumentsRequest Request { get; }
        public GetSharedDocumentsResponseInvalidUserID(GetSharedDocumentsRequest request)
        {
            Request = request;
        }
    }
}
