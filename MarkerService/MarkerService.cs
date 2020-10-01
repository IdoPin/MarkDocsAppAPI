using DIContracts;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Markers;
using MarkDocsAppContracts.DTO.Markers.Req_Res;
using MarkDocsAppContracts.Interfaces;
using MarkDocsAppContracts.Interfaces.BLL;
using MarkDocsAppContracts.Interfaces.DAL;
using SocketContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MarkerService
{
    [Register(Policy.Transient, typeof(IMarkerService))]
    public class MarkerService : IMarkerService
    {
        IMarkDocsAppDAL _dal;
        IWSUserService _socket;

        public MarkerService(IMarkDocsAppDAL dal, IWSUserService socket)
        {
            _dal = dal;
            _socket = socket;
        }

        public async Task<Response> CreateMarker(CreateMarkerRequest request)
        {
            Response response = new CreateMarkerResponseInvalidMarkerData(request);
            if (_dal.isUserExists(request.UserID) && _dal.isDocExists(request.DocID) && isValidMarkerType(request.MarkerType))
            {
                try
                {
                    //create marker
                    var markerID = Guid.NewGuid().ToString();
                    DataSet ds = _dal.CreateMarker(request.DocID, markerID, request.UserID, request.MarkerType, request.StrokeColor, 
                        request.BackgroundColor,request.X, request.Y, request.XRadius, request.YRadius);
                    response = new CreateMarkerResponseOK(request);

                    //update other users
                    List<string> usersIDs = new List<string>();
                    DataSet ds2 = _dal.GetSharedUsers(request.DocID);
                    foreach (DataRow row in ds2.Tables[0].Rows)
                    {
                        usersIDs.Add((string)row["USER_ID"]);
                    }
                    DataSet ds3 = _dal.GetDocument(request.DocID);
                    DataRow docData = ds3.Tables[0].Rows[0];
                    usersIDs.Add((string)docData["USER_ID"]);
                    foreach (string userID in usersIDs)
                    {
                         await _socket.Send(userID, "newMarkerUpdate");
                    }

                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> GetMarker(GetMarkerRequest request)
        {
            Response response = new GetMarkerResponseInvalid(request);
            try
            {
                Marker marker = new Marker();
                DataSet ds = _dal.GetMarker(request.MarkerID);
                var markerData = ds.Tables[0].Rows[0];

                marker.DocID = (string)markerData["DOC_ID"];
                marker.MarkerID = (string)markerData["MARKER_ID"];
                marker.UserID = (string)markerData["USER_ID"];
                marker.MarkerType = (string)markerData["MARKER_TYPE"];
                marker.StrokeColor = (string)markerData["STROKE_COLOR"];
                marker.BackgroundColor = (string)markerData["BACKGROUND_COLOR"];
                marker.X = (string)markerData["X"];
                marker.Y = (string)markerData["Y"];
                marker.XRadius = (string)markerData["XRADIUS"];
                marker.YRadius = (string)markerData["YRADIUS"];

                response = new GetMarkerResponseOK(marker);
            }
            catch (Exception ex)
            {
                response = new AppResponseError(ex.Message);
            }
            return response;

        }
        public async Task<Response> GetMarkers(GetMarkersRequest request)
        {
            Response response = new GetMarkersResponseInvalidDocID(request);
            if (_dal.isDocExists(request.DocID))
            {
                try
                {
                    List<Marker> markers = new List<Marker>();
                    DataSet ds = _dal.GetMarkers(request.DocID);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var marker = new Marker();
                        marker.DocID = (string)row["DOC_ID"];
                        marker.MarkerID = (string)row["MARKER_ID"];
                        marker.UserID = (string)row["USER_ID"];
                        marker.MarkerType = (string)row["MARKER_TYPE"];
                        marker.StrokeColor = (string)row["STROKE_COLOR"];
                        marker.BackgroundColor = (string)row["BACKGROUND_COLOR"];
                        marker.X = (string)row["X"];
                        marker.Y = (string)row["Y"];
                        marker.XRadius = (string)row["XRADIUS"];
                        marker.YRadius = (string)row["YRADIUS"];

                        markers.Add(marker);
                    }

                    response = new GetMarkersResponseOK(markers);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;

        }

        public async Task<Response> RemoveMarker(RemoveMarkerRequest request)
        {
            Response response = new RemoveMarkerResponseInvalidMarkerID(request);
            if (_dal.isMarkerExists(request.MarkerID))
            {
                try
                {
                    _dal.RemoveMarker(request.MarkerID);
                    response = new RemoveMarkerResponseOK(request);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        private bool isValidMarkerType(string markerType)
        {
            return (markerType == "ellipse" || markerType == "rectangle");
        }
    }
}
