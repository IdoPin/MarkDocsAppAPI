using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class LogInResponseInvalidPasswordOrUserID : LogInResponse
    {
        public LogInRequest Request { get; }
        public LogInResponseInvalidPasswordOrUserID(LogInRequest request)
        {
            Request = request;
        }
    }
}
