using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Users.Req_Res;
using System.Threading.Tasks;

namespace MarkDocsAppContracts.Interfaces
{
    public interface IUserService
    {
        public Task<Response> CreateUser(CreateUserRequest request);
        public Task<Response> LogIn(LogInRequest request);
        public Task<Response> UnSubscribe(UnSubscribeRequest request);
        public Task<Response> GetUsers(GetUsersRequest request);
        public Task<Response> GetUser(GetUserRequest request);

    }
}
