using DIContracts;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Users;
using MarkDocsAppContracts.DTO.Users.Req_Res;
using MarkDocsAppContracts.Interfaces;
using MarkDocsAppContracts.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace UserService
{
    [Register(Policy.Transient, typeof(IUserService))]
    public class UserService : IUserService
    {
        IMarkDocsAppDAL _dal;

        public UserService(IMarkDocsAppDAL dal)
        {
            _dal = dal;
        }

        public async Task<Response> CreateUser(CreateUserRequest request)
        {
            Response response = new CreateUserResponseInvalidUserID(request);
            if (!_dal.isUserExists(request.User.UserID))
            {
                try
                {
                    DataSet ds = _dal.CreateUser(request.User.UserID, request.User.UserName);
                    var userData = ds.Tables[0].Rows[0];
                    var user = new User();
                    user.UserID = (string)userData["USER_ID"];
                    user.UserName = (string)userData["USER_NAME"];
                    response = new CreateUserResponseOK(user);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> LogIn(LogInRequest request)
        {
            Response response = new LogInResponseInvalidPasswordOrUserID(request);
            if (_dal.isUserExists(request.User.UserID))
            {
                try
                {
                    DataSet ds = _dal.LogIn(request.User.UserID,request.User.UserName);
                    var res = ds.Tables[0].Rows.Count;
                    if (res != 0)
                    {
                        response = new LogInResponseOK(request);
                    }
                    
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> UnSubscribe(UnSubscribeRequest request)
        {
            Response response = new UnSubscribeResponseInvalidUserID(request);
            if (_dal.isUserExists(request.User.UserID))
            {
                try
                {
                    _dal.UnSubscribe(request.User.UserID,request.User.UserName);
                    response = new UnSubscribeResponseOK(request);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> GetUser(GetUserRequest request)
        {
            Response response = new GetUserResponseInvalidUserID(request);

            try
            {

               DataSet ds = _dal.GetUser(request.UserID);
               var userData = ds.Tables[0].Rows[0];
               var user = new User();
               user.UserID = (string)userData["USER_ID"];
               user.UserName = (string)userData["USER_NAME"];
               response = new GetUserResponseOK(user);
            }
            catch (Exception ex)
            {
               response = new GetUserResponseInvalidUserID(request);
            }

            return response;
        }
        public async Task<Response> GetUsers(GetUsersRequest request)
        {
            Response response = new GetUsersResponseInvalid(request);
            if (_dal.isUserExists(request.User.UserID))
            {
                try
                {
                    List<User> users = new List<User>();
                    DataSet db = _dal.GetUsers();
                    foreach (DataRow row in db.Tables[0].Rows)
                    {
                        var user = new User();
                        user.UserID = (string)row["USER_ID"];
                        user.UserName = (string)row["USER_NAME"];
                        users.Add(user);
                    }
                    response = new GetUsersResponseOK(users);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

    }
}
