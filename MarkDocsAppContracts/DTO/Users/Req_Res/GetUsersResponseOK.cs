using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Users.Req_Res
{
    public class GetUsersResponseOK : GetUsersResponse
    {
        public List<User> Users { get; }
        public GetUsersResponseOK(List<User> users)
        {
            Users = users;
        }
    }
}
