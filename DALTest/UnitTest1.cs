using DALContracts;
using NUnit.Framework;
using ORDAL;
using System;
using System.Data;

namespace DALTest
{
    public class Tests
    {
        private IInfraDAL _dal;
        private IDBConnection _connection;
        [SetUp]
        public void Setup()
        {
            _dal = new InfraDAL();
            var strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
                          "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));" +
                          "User Id=MIZRAHI;Password=1234;";
            _connection = _dal.Connect(strConn);
        }
        //SELECT TEST
        [Test]
        public void ExecuteQueryTest()
        {
            var expected = 1;
            DataSet ds = _dal.ExecuteQuery(_connection, "SELECT * FROM USERS WHERE USER_ID = 'alon@gmail.com' AND USER_NAME = 'alon' AND REMOVED = 0");
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        //CREATE TESTS
        [Test]
        public void CreateUserTest()
        {
            var expected = 1;
            IDBParameter userId = _dal.InParameter("USER_ID", "gil@gmail.com");
            IDBParameter userName = _dal.InParameter("USER_NAME", "gil");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_CREATE_USER", userId, userName, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CreateDocumentTest()
        {
            var expected = 1;
            IDBParameter docId = _dal.InParameter("DOC_ID", "123");
            IDBParameter userId = _dal.InParameter("USER_ID", "gil@gmail.com");
            IDBParameter docName = _dal.InParameter("DOCUMENT_NAME", "gil's document");
            IDBParameter imgUrl = _dal.InParameter("IMAGE_URL", "www.imageOfGil");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_CREATE_DOCUMNET", docId, userId, docName, imgUrl, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CreateShareTest()
        {
            var expected = 1;
            IDBParameter docId = _dal.InParameter("DOC_ID", "123");
            IDBParameter userId = _dal.InParameter("USER_ID", "gil@gmail.com");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_CREATE_SHARE", docId, userId, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CreateMarkerTest()
        {
            var expected = 1;
            IDBParameter docId = _dal.InParameter("DOC_ID", "123");
            IDBParameter markerId = _dal.InParameter("MARKER_ID", "111");
            IDBParameter userId = _dal.InParameter("USER_ID", "gil@gmail.com");
            IDBParameter markerType = _dal.InParameter("MARKER_TYPE", "ellipse");
            IDBParameter strokeColor = _dal.InParameter("STROKE_COLOR", "black");
            IDBParameter backgroundColor = _dal.InParameter("BACKGROUND_COLOR", "white");
            IDBParameter x = _dal.InParameter("X", "12");
            IDBParameter y = _dal.InParameter("Y", "13");
            IDBParameter xRadius = _dal.InParameter("XRADIUS", "22");
            IDBParameter yRadius = _dal.InParameter("YRADIUS", "23");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_CREATE_MARKER", docId, markerId, userId, markerType,
                 strokeColor, backgroundColor, x, y, xRadius, yRadius, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        //REMOVE TESTS
        [Test]
        public void UnSubscribeTest()
        {
            var expected = 1;
            IDBParameter userId = _dal.InParameter("USER_ID", "gil@gmail.com");
            IDBParameter userName = _dal.InParameter("USER_NAME", "gil");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_UNSUBSCRIBE", userId, userName, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveDocumentTest()
        {
            var expected = 0;
            IDBParameter docId = _dal.InParameter("DOC_ID", "123");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_REMOVE_DOCUMENT", docId, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveShareTest()
        {
            var expected = 0;
            IDBParameter docId = _dal.InParameter("DOC_ID", "123");
            IDBParameter userId = _dal.InParameter("USER_ID", "gil@gmail.com");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_REMOVE_SHARE", docId, userId, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveMarkerTest()
        {
            var expected = 0;
            IDBParameter markerId = _dal.InParameter("MARKER_ID", "111");
            IDBParameter outParam = _dal.OutParameter();

            DataSet ds = _dal.ExecuteSPQuery(_connection, "SP_REMOVE_MARKER", markerId, outParam);
            var actual = ds.Tables[0].Rows.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}