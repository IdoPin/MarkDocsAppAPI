using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class GetDocumentsResponseOK : GetDocumentsResponse
    {
        public List<Document> Documents { get; }
        public GetDocumentsResponseOK(List<Document> documents)
        {
            Documents = documents;
        }
    }
}

