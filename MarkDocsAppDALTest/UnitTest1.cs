using MarkDocsAppDAL;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using ORDAL;
using System.Data;

namespace MarkDocsAppDALTest
{
    public class Tests
    {
        IConfiguration _configuration;
        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        [Test]
        public void Test1()
        {
            var dal = new MarkDocsAppDALImpl(new InfraDAL(),_configuration);
            DataSet ds = dal.GetUser("alon@gmail.com");
            var userData = ds.Tables[0].Rows[0];
            var actual = (string)userData["USER_NAME"];
            var expexted = "alon";
            Assert.AreEqual(expexted,actual);
        }
    }
}