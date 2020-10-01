using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class CreateUserResponseOK : CreateUserResponse
    {
        public User User { get; }
        public CreateUserResponseOK(User user)
        {
            User = user;
        }
    }
}
