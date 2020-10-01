using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class CreateDocumentRequest
    {
        public string UserID { get; set; }
        public string DocumentName { get; set; }
        public string ImageURL { get; set; }
    }
}
