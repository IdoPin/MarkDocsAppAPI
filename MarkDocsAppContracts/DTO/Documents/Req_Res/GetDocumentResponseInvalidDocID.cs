using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class GetDocumentResponseInvalidDocID : GetDocumentResponse
    {
        public GetDocumentRequest Request { get; }
        public GetDocumentResponseInvalidDocID(GetDocumentRequest request)
        {
            Request = request;
        }
    }
}
