using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class UnSubscribeResponseOK : UnSubscribeResponse
    {
        public UnSubscribeRequest Request { get; }
        public UnSubscribeResponseOK(UnSubscribeRequest request)
        {
            Request = request;
        }
    }
}
