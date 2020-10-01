using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class CreateDocumentResponseInvalidUserID : CreateDocumentResponse
    {
        public CreateDocumentRequest Request { get; }
        public CreateDocumentResponseInvalidUserID(CreateDocumentRequest request)
        {
            Request = request;
        }
    }
}

