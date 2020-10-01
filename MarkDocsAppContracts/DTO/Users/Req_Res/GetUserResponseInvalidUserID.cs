using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class GetUserResponseInvalidUserID : GetUserResponse
    {
        public GetUserRequest Request { get; }
        public GetUserResponseInvalidUserID(GetUserRequest request)
        {
            Request = request;
        }
    }
}
