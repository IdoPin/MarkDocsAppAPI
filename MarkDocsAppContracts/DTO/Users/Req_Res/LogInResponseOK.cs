using System;
using System.Collections.Generic;
using System.Text;
namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class LogInResponseOK : LogInResponse
    {
        public LogInRequest Request { get; }
        public LogInResponseOK(LogInRequest request)
        {
            Request = request;
        }
    }
}
