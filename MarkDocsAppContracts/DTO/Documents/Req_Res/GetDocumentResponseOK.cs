using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class GetDocumentResponseOK : GetDocumentResponse
    {
        public Document Document { get; }
        public GetDocumentResponseOK(Document document)
        {
            Document = document;
        }
    }
}
