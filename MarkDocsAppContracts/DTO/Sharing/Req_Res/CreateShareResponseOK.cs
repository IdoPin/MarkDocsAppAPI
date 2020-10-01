using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Sharing.Req_Res
{
    public class CreateShareResponseOK : CreateShareResponse
    {
        public CreateShareRequest Request { get; }
        public CreateShareResponseOK(CreateShareRequest request)
        {
            Request = request;
        }
    }
}
