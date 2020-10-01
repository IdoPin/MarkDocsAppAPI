using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Sharing.Req_Res
{
    public class RemoveShareResponseInvalidUserID : RemoveShareResponse
    {
        public RemoveShareRequest Request { get; }
        public RemoveShareResponseInvalidUserID(RemoveShareRequest request)
        {
            Request = request;
        }
    }
}
