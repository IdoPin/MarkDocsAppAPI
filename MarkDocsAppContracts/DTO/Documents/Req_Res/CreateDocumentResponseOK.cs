﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Documents.Req_Res
{
    public class CreateDocumentResponseOK : CreateDocumentResponse
    {
        public CreateDocumentRequest Request { get; }
        public CreateDocumentResponseOK(CreateDocumentRequest request)
        {
            Request = request;
        }
    }
}

