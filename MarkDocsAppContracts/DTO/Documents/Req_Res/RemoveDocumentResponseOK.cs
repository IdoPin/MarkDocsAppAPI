using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class RemoveDocumentResponseOK : RemoveDocumentResponse
    {
        public RemoveDocumentRequest Request { get; }
        public RemoveDocumentResponseOK(RemoveDocumentRequest request)
        {
            Request = request;
        }
    }
}

