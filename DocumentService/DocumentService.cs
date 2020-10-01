using DIContracts;
using MarkDocsAppContracts.DTO;
using MarkDocsAppContracts.DTO.Documents;
using MarkDocsAppContracts.DTO.Documents.Req_Res;
using MarkDocsAppContracts.Interfaces;
using MarkDocsAppContracts.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DocumentService
{
    [Register(Policy.Transient, typeof(IDocumentService))]
    public class DocumentService : IDocumentService
    {
        IMarkDocsAppDAL _dal;
        public DocumentService(IMarkDocsAppDAL dal)
        {
            _dal = dal;
        }

        public async Task<Response> CreateDocument(CreateDocumentRequest request)
        {
            Response response = new CreateDocumentResponseInvalidUserID(request);
            if(_dal.isUserExists(request.UserID))
            {
                try
                {
                    var docID = Guid.NewGuid().ToString();
                    _dal.CreateDocument(request.UserID, docID, request.DocumentName, request.ImageURL);
                    response = new CreateDocumentResponseOK(request);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> GetDocument(GetDocumentRequest request)
        {
            Response response = new GetDocumentResponseInvalidDocID(request);
            if (_dal.isDocExists(request.DocID))
            {
                try
                {
                    DataSet ds = _dal.GetDocument(request.DocID);
                    var docData = ds.Tables[0].Rows[0];
                    var doc = new Document();
                    doc.DocID = (string)docData["DOC_ID"];
                    doc.UserID = (string)docData["USER_ID"];
                    doc.DocumentName = (string)docData["DOCUMENT_NAME"];
                    doc.ImageURL = (string)docData["IMAGE_URL"];

                    response = new GetDocumentResponseOK(doc);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }

        public async Task<Response> GetDocuments(GetDocumentsRequest request)
        {
            Response response = new GetDocumentsResponseInvalidUserID(request);
            if (_dal.isUserExists(request.UserID))
            {
                try
                {
                    DataSet ds = _dal.GetDocuments(request.UserID);
                    List<Document> docs = new List<Document>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var doc = new Document();
                        doc.DocID = (string)row["DOC_ID"];
                        doc.UserID = (string)row["USER_ID"];
                        doc.DocumentName = (string)row["DOCUMENT_NAME"];
                        doc.ImageURL = (string)row["IMAGE_URL"];
                        docs.Add(doc);
                    }

                    response = new GetDocumentsResponseOK(docs);
                }
                catch (Exception ex)
                {
                    response = new AppResponseError(ex.Message);
                }
            }
            return response;
        }
        public async Task<Response> RemoveDocument(RemoveDocumentRequest request)
        {
            Response response = new RemoveDocumentResponseInvalidDocID(request);
            if (_dal.isDocExists(request.DocID))
            {
                try
                {
                    _dal.RemoveDocument(request.DocID);
                    response = new RemoveDocumentResponseOK(request);
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

