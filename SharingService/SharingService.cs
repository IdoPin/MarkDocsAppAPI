using DALContracts;
using DIContracts;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Sharing.Req_Res;
using MarkDocsAppContracts.Interfaces;
using MarkDocsAppContracts.Interfaces.BLL;
using MarkDocsAppContracts.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using SocketContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SharingService
{
    [Register(Policy.Transient, typeof(ISharingService))]
    public class SharingService : ISharingService
    {
        IMarkDocsAppDAL _dal;
        IWSUserService _socket;

        public SharingService(IMarkDocsAppDAL dal, IWSUserService socket)
        {
            _dal = dal;
            _socket = socket;
        }

        public async Task<Response> CreateShare(CreateShareRequest request)
        {
            Response response = new CreateShareResponseInvalidUserID(request);
            if(_dal.isUserExists(request.Share.UserID) && _dal.isDocExists(request.Share.DocID))
            {
                try
                {
                    //create share
                    DataSet ds = _dal.CreateShare(request.Share.DocID,request.Share.UserID);
                    response = new CreateShareResponseOK(request);
                    //update user for new share
                    await _socket.Send(request.Share.UserID, "newDocumentUpdate");
                }
                catch(Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> GetSharedDocuments(GetSharedDocumentsRequest request)
        {
            Response response = new GetSharedDocumentsResponseInvalidUserID(request);
            if(_dal.isUserExists(request.UserID))
            {
                try
                {
                    List<string> docsIDs = new List<string>();
                    DataSet ds = _dal.GetSharedDocuments(request.UserID);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        docsIDs.Add((string)row["DOC_ID"]);
                    }
                    response = new GetSharedDocumentsResponseOK(docsIDs);


                }
                catch(Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }
        public async Task<Response> GetSharedUsers(GetSharedUsersRequest request)
        {
            Response response = new GetSharedUsersResponseInvalidDocID(request);
            if (_dal.isDocExists(request.DocID))
            {
                try
                {
                    List<string> usersIDs = new List<string>();
                    DataSet ds = _dal.GetSharedUsers(request.DocID);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usersIDs.Add((string)row["USER_ID"]);
                    }
                    response = new GetSharedUsersResponseOK(usersIDs);


                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> RemoveShare(RemoveShareRequest request)
        {
            Response response = new RemoveShareResponseInvalidUserID(request);
            if (_dal.isUserExists(request.Share.UserID) && _dal.isDocExists(request.Share.DocID))
            {
                try
                {
                    //remove share
                    DataSet ds = _dal.RemoveShare(request.Share.DocID, request.Share.UserID);
                    response = new RemoveShareResponseOK(request);
                    //update user for new share
                   await _socket.Send(request.Share.UserID, "newDocumentUpdate");
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
