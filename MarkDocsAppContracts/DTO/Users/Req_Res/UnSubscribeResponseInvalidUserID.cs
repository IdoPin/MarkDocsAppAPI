using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class UnSubscribeResponseInvalidUserID : UnSubscribeResponse
    {
        public UnSubscribeRequest Request { get; }
        public UnSubscribeResponseInvalidUserID(UnSubscribeRequest request)
        {
            Request = request;
        }
    }
}
