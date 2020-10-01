using MarkDocsAppContracts.DTO.Documents;
using MarkDocsAppContracts.DTO.Markers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Sharing.Req_Res
{
    public class GetSharedDocumentsResponseOK : GetSharedDocumentsResponse
    {
        public List<string> Documents { get; }
        public GetSharedDocumentsResponseOK(List<string> documents)
        {
            Documents = documents;
        }
    }
}
