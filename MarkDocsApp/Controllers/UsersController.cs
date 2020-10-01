using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Users.Req_Res;
using MarkDocsAppContracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkDocsApp.Controllers
{
    /*    [Route("api/[controller]")]*/
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<Response> CreateUser(CreateUserRequest request)
        {
            return await _userService.CreateUser(request);
        }

        [HttpPost]
        public async Task<Response> Login(LogInRequest request)
        {
            return await _userService.LogIn(request);
        }

        [HttpPost]
        public async Task<Response> UnSubscribe(UnSubscribeRequest request)
        {
            return await _userService.UnSubscribe(request);
        }

        [HttpPost]
        public async Task<Response> GetUsers(GetUsersRequest request)
        {
            return await _userService.GetUsers(request);
        }

        [HttpPost]
        public async Task<Response> GetUser(GetUserRequest request)
        {
            return await _userService.GetUser(request);
        }
    }
}
