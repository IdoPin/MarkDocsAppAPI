using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class RemoveDocumentResponseInvalidDocID : RemoveDocumentResponse
    {
        public RemoveDocumentRequest Request { get; }
        public RemoveDocumentResponseInvalidDocID(RemoveDocumentRequest request)
        {
            Request = request;
        }
    }
}

