using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class CreateUserResponseInvalidUserID : CreateUserResponse
    {
        public CreateUserRequest Request { get; }
        public CreateUserResponseInvalidUserID(CreateUserRequest request)
        {
            Request = request;
        }
    }
}
