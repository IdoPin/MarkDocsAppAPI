using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class GetUserResponseOK : GetUserResponse
    {
        public User User { get; }
        public GetUserResponseOK(User user)
        {
            User = user;
        }
    }
}
