using DALContracts;
using System.Data;

namespace MarkDocsAppContracts.Interfaces.DAL
{
    public interface IMarkDocsAppDAL
    {
        //Documents
        DataSet CreateDocument(string UserID, string DocumentID, string DocumentName, string ImageURL);
        DataSet GetDocument(string DocID);
        DataSet GetDocuments(string UserID);
        DataSet RemoveDocument(string DocID);
        //Markers
        DataSet CreateMarker(string DocID, string MarkerID, string UserID, string MarkerType, string StrokeColor, string BackgroundColor, string X,
            string Y, string XRadius, string YRadius);
        DataSet GetMarker(string markerID);
        DataSet GetMarkers(string DocID);
        DataSet RemoveMarker(string MarkerID);
        //Shares
        DataSet CreateShare(string DocID, string UserID);
        DataSet GetSharedDocuments(string UserID);
        DataSet GetSharedUsers(string DocID);
        DataSet RemoveShare(string DocID, string UserID);
        //Users
        DataSet CreateUser(string UserID, string UserName);
        DataSet LogIn(string UserID, string UserName);
        DataSet UnSubscribe(string UserID, string UserName);
        DataSet GetUsers();
        DataSet GetUser(string UserID);
        //validations
        bool isUserExists(string UserID);
        bool isDocExists(string DocID);
        bool isMarkerExists(string markerID);
    }
}
