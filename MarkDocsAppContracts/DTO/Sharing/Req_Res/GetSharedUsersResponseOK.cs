using MarkDocsAppContracts.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.Sharing.Req_Res
{
    public class GetSharedUsersResponseOK : GetSharedUsersResponse
    {
        public List<string> Users { get; }
        public GetSharedUsersResponseOK(List<string> users)
        {
            Users = users;
        }
    }
}
