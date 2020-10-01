using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Sharing.Req_Res
{
    public class CreateShareResponseInvalidUserID : CreateShareResponse
    {
        public CreateShareRequest Request { get; }
        public CreateShareResponseInvalidUserID(CreateShareRequest request)
        {
            Request = request;
        }
    }
}
