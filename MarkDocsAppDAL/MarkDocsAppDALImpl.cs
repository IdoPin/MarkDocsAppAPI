using DALContracts;
using DIContracts;
using MarkDocsAppContracts.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace MarkDocsAppDAL
{
    [Register(Policy.Transient, typeof(IMarkDocsAppDAL))]
    public class MarkDocsAppDALImpl : IMarkDocsAppDAL
    {
        IInfraDAL _dal;
        IConfiguration _configuration;
        IDBConnection _connection;

        public MarkDocsAppDALImpl(IInfraDAL dal, IConfiguration configuration)
        {
            _dal = dal;
            _configuration = configuration; 
            _connection = _dal.Connect(_configuration.GetConnectionString("MarkDocsDBConnection"));
        }

        
        public DataSet CreateDocument(string UserID, string DocumentID, string DocumentName, string ImageURL)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocumentID);
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter docName = _dal.InParameter("DOCUMENT_NAME", DocumentName);
            IDBParameter imgUrl = _dal.InParameter("IMAGE_URL", ImageURL);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_CREATE_DOCUMNET", docId, userId, docName, imgUrl, outParam);
        }

        public DataSet CreateMarker(string DocID,string MarkerID, string UserID, string MarkerType, string StrokeColor, string BackgroundColor, string X,
            string Y, string XRadius, string YRadius)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocID);
            IDBParameter markerId = _dal.InParameter("MARKER_ID", MarkerID);
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter markerType = _dal.InParameter("MARKER_TYPE", MarkerType);
            IDBParameter strokeColor = _dal.InParameter("STROKE_COLOR", StrokeColor);
            IDBParameter backgroundColor = _dal.InParameter("BACKGROUND_COLOR", BackgroundColor);
            IDBParameter x = _dal.InParameter("X", X);
            IDBParameter y = _dal.InParameter("Y", Y);
            IDBParameter xRadius = _dal.InParameter("XRADIUS", XRadius);
            IDBParameter yRadius = _dal.InParameter("YRADIUS", YRadius);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_CREATE_MARKER", docId, markerId, userId, markerType,
                         strokeColor, backgroundColor, x, y, xRadius, yRadius, outParam);
        }

        public DataSet CreateShare(string DocID, string UserID)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocID);
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_CREATE_SHARE", docId, userId, outParam);
        }

        public DataSet CreateUser(string UserID, string UserName)
        {
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter userName = _dal.InParameter("USER_NAME", UserName);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_CREATE_USER", userId, userName, outParam);
        }

        public DataSet GetDocument(string DocID)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_GET_DOCUMENT", docId, outParam);
        }

        public DataSet GetDocuments(string UserID)
        {
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_GET_DOCUMENTS", userId, outParam);
        }
        public DataSet GetMarker(string markerID)
        {
            IDBParameter markerId = _dal.InParameter("MARKER_ID", markerID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_GET_MARKER", markerId, outParam);
        }

        public DataSet GetMarkers(string DocID)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_GET_MARKERS", docId, outParam);
        }

        public DataSet GetSharedDocuments(string UserID)
        {
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_GET_SHARED_DOCUMENTS", userId, outParam);
        }

        public DataSet GetSharedUsers(string DocID)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_GET_SHARED_USERS", docId, outParam);
        }

        public DataSet GetUser(string UserID)
        {
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_GET_USER", userId, outParam);
        }

        public DataSet GetUsers()
        {
            IDBParameter outParam = _dal.OutParameter();
            
            return _dal.ExecuteSPQuery(_connection, "SP_GET_USERS", outParam);
        }

        public DataSet LogIn(string UserID, string UserName)
        {
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter userName = _dal.InParameter("USER_NAME", UserName);
            IDBParameter outParam = _dal.OutParameter();
            
            return _dal.ExecuteSPQuery(_connection, "SP_LOGIN", userId, userName, outParam);
        }

        public DataSet RemoveDocument(string DocID)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_REMOVE_DOCUMENT", docId, outParam);
        }

        public DataSet RemoveMarker(string MarkerID)
        {
            IDBParameter markerId = _dal.InParameter("MARKER_ID", MarkerID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_REMOVE_MARKER", markerId, outParam);
        }

        public DataSet RemoveShare(string DocID, string UserID)
        {
            IDBParameter docId = _dal.InParameter("DOC_ID", DocID);
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter outParam = _dal.OutParameter();

            return _dal.ExecuteSPQuery(_connection, "SP_REMOVE_SHARE", docId, userId, outParam);
        }

        public DataSet UnSubscribe(string UserID, string UserName)
        {
            IDBParameter userId = _dal.InParameter("USER_ID", UserID);
            IDBParameter userName = _dal.InParameter("USER_NAME", UserName);
            IDBParameter outParam = _dal.OutParameter();
            
            return _dal.ExecuteSPQuery(_connection, "SP_UNSUBSCRIBE", userId, userName, outParam);
        }

        public bool isUserExists(string UserID)
        {
            var retval = false;
            DataSet ds = this.GetUser(UserID);
            var res = ds.Tables[0].Rows.Count;
            if (res != 0)
            {
                retval = true;
            }

            return retval;
        }
        public bool isDocExists(string DocID)
        {
            var retval = false;
            DataSet ds = this.GetDocument(DocID);
            var res = ds.Tables[0].Rows.Count;
            if (res != 0)
            {
                retval = true;
            }

            return retval;
        }
        public bool isMarkerExists(string markerID)
        {
            var retval = false;
            DataSet ds = this.GetMarker(markerID);
            var res = ds.Tables[0].Rows.Count;
            if (res != 0)
            {
                retval = true;
            }

            return retval;
        }
    }
}
