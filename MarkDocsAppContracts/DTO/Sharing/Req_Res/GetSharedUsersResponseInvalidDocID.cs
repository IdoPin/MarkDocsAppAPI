using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Sharing.Req_Res
{
    public class GetSharedUsersResponseInvalidDocID : GetSharedUsersResponse
    {
        public GetSharedUsersRequest Request { get; }
        public GetSharedUsersResponseInvalidDocID(GetSharedUsersRequest request)
        {
            Request = request;
        }
    }
}
