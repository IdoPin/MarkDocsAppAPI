using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class GetDocumentsResponseInvalidUserID : GetDocumentsResponse
    {
        public GetDocumentsRequest Request { get; }
        public GetDocumentsResponseInvalidUserID(GetDocumentsRequest request)
        {
            Request = request;
        }
    }
}

